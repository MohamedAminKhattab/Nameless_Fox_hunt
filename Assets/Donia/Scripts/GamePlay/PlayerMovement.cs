using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Vector3SO movement;
    Rigidbody rb;
    [SerializeField]
    FloatSO speed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    Vector2SO joyStickMovement;
    Vector3 moveVec;
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    
    void FixedUpdate()
    {
        moveVec.x = joyStickMovement.value.x;
        moveVec.z = joyStickMovement.value.y;
        moveVec.y = 0;
        rb.velocity=movement.value*speed.value;
        rb.velocity=moveVec*speed.value;
        Vector3 movementDirection = movement.value.normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
