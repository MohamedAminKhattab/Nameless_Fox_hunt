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
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    
    void FixedUpdate()
    {
        rb.velocity=movement.vec_3*speed.float_SO;
        Vector3 movementDirection = movement.vec_3.normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
