using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    float velocity = 0.0f;
    [SerializeField]
    float acceleration = 2f;
    [SerializeField]
    float deceleration = 2f;
    int velocityHash;
    [SerializeField]
    Vector3SO movement;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        velocityHash = Animator.StringToHash("VelocityX");
        velocityHash = Animator.StringToHash("VelocityZ");
    }

    void Update()
    {
        bool pressForeward = movement.value.z == 1;
        bool pressBackward = movement.value.z == -1;
        bool rightPressed = movement.value.x == 1;
        bool leftPressed = movement.value.x == -1;

        if ((pressForeward || pressBackward || rightPressed || leftPressed))
        {
            velocity += Time.deltaTime * acceleration;
        }
        else
        {
            velocity -= Time.deltaTime * deceleration;
        }
        velocity = Mathf.Clamp(velocity, 0.0f, 1.0f);

        animator.SetFloat("Velocity", velocity);
    }
}
