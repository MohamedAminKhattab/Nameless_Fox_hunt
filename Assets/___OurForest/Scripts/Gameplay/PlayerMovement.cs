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
    [SerializeField]
    BoolSO freez;
    Vector3 moveVec;
    Vector3 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        freez.state = false;
        moveVec = Vector3.zero;
    }


    void FixedUpdate()
    {

        if (!freez.state)
        {
            //Debug.Log("Move");
            moveVec.x = joyStickMovement.value.x;
            moveVec.z = joyStickMovement.value.y;
            if (moveVec.x != 0 || moveVec.z != 0)
            {
                rb.velocity = moveVec * speed.value;
                movementDirection = moveVec.normalized;
            }
            else
            {
                rb.velocity = movement.value * speed.value;
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
           // Debug.Log("Not Move");

        }
    }
}
