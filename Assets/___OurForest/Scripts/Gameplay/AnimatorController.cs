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
    [SerializeField]
    Vector2SO joyStickMove;
    [SerializeField]
    BoolSO pickUpFood;
    [SerializeField]
    BoolSO FetchResource;
    [SerializeField]
    BoolSO FetchAnim;
    [SerializeField]
    BoolSO CutAnim;
    [SerializeField]
    BoolSO EatAnim;
    [SerializeField]
    BoolSO HideAnim;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        pickUpFood.state = false;
        velocityHash = Animator.StringToHash("VelocityX");
        velocityHash = Animator.StringToHash("VelocityZ");
    }

    void Update()
    {
        if (joyStickMove.value.x != 0 || joyStickMove.value.y != 0)
        {
            movement.value.x = joyStickMove.value.x;
            movement.value.y = 0;
            movement.value.z = joyStickMove.value.y;
        }
        //Debug.Log(joyStickMove.value.x);
        //Debug.Log(joyStickMove.value.y);
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
        animator.SetBool("PickUp", FetchAnim.state);
        animator.SetBool("CutWood", CutAnim.state);
        animator.SetBool("EatFood", EatAnim.state);
        animator.SetBool("Hiding", HideAnim.state);
        FetchAnim.state = false;
        CutAnim.state = false;
        EatAnim.state = false;

    }
    void OnTriggerExit(Collider other)
    {
        HideAnim.state = false;
    }
}
