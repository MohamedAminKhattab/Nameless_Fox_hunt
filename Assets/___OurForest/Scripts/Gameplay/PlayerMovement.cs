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
    [SerializeField] BoolSO freeze;
    Vector3 moveVec;
    Vector3 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveVec = Vector3.zero;
    }


    void FixedUpdate()
    {
        if(!freeze.state)
        {
            moveVec.x = joyStickMovement.value.x;
            moveVec.z = joyStickMovement.value.y;
            if (moveVec.x != 0 || moveVec.z != 0)
            {
                rb.velocity = moveVec * speed.value;
                rb.velocity += Physics.gravity * Time.fixedDeltaTime;
                movementDirection = moveVec.normalized;
            }
            else
            {
                rb.velocity = movement.value * speed.value;
                rb.velocity += Physics.gravity * Time.fixedDeltaTime;
                movementDirection = movement.value.normalized;
            }
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}