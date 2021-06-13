using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    [SerializeField]
    float acceleration = 2f;
    [SerializeField]
    float deceleration = 2f;
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
    BoolSO crouch;
    [SerializeField]
    BoolSO CutAnim;
    [SerializeField]
    BoolSO EatAnim;
    [SerializeField]
    BoolSO HideAnim;
    [SerializeField]
    BoolSO crouchAnim;
    [SerializeField]
    BoolSO attackAnim;
    [SerializeField]
    BoolSO attack;
    [SerializeField]
    BoolSO deathAnim;
    [SerializeField]
    HealthSO playerHealth;
    [SerializeField]
    BoolSO freez;
    void Start()
    {
        animator = GetComponent<Animator>();
        pickUpFood.state = false;
        crouchAnim.state = false;
        crouch.state = false;
        attack.state = false;
        attackAnim.state = false;
        deathAnim.state = false;
        freez.state = false;
        joyStickMove.value = Vector2.zero;
        movement.value = Vector3.zero;
    }

    void Update()
    {
        if (joyStickMove.value.x != 0 || joyStickMove.value.y != 0)
        {
            movement.value.x = joyStickMove.value.x;
            movement.value.y = 0;
            movement.value.z = joyStickMove.value.y;
        }

        bool pressForeward = movement.value.z > 0;
        bool pressBackward = movement.value.z < 0;
        bool rightPressed = movement.value.x > 0;
        bool leftPressed = movement.value.x < 0;

        if (pressForeward || pressBackward || rightPressed || leftPressed)
        {
            velocity += Time.deltaTime * acceleration;
        }
        else
        {
            velocity -= Time.deltaTime * deceleration;
        }
        velocity = Mathf.Clamp(velocity, 0.0f, 1.0f);


        if (crouch.state)
            crouchAnim.state = true;

        else
            crouchAnim.state = false;
        if (!freez.state)
        {
            animator.SetFloat("Velocity", velocity);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        //animator.SetBool("CutWood", CutAnim.state);
        animator.SetBool("EatFood", EatAnim.state);
        animator.SetBool("Dead", playerHealth.dead);
        animator.SetBool("crouch", crouchAnim.state);
        animator.SetBool("Attack", attackAnim.state);
        animator.SetBool("PickUp", FetchAnim.state);
        //CutAnim.state = false;
        EatAnim.state = false;
        attackAnim.state = false;
        crouch.state = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            HideAnim.state = true;
            animator.SetBool("Hiding", HideAnim.state);
            //Debug.Log("hiding");
        }

        if (other.gameObject.CompareTag("Vine"))
        {
            FetchAnim.state = true;
            animator.SetBool("PickUp", FetchAnim.state);
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            FetchAnim.state = true;
            animator.SetBool("PickUp", FetchAnim.state);

        }
        if (other.gameObject.CompareTag("Food"))
        {
            FetchAnim.state = true;
            animator.SetBool("PickUp", FetchAnim.state);

        }

        if (other.gameObject.CompareTag("Wood"))
        {
            FetchAnim.state = true;
            animator.SetBool("PickUp", FetchAnim.state);
        }

        if (other.gameObject.CompareTag("Weapon"))
        {
            FetchAnim.state = true;
            animator.SetBool("PickUp", FetchAnim.state);
        }

    }
    void OnTriggerExit(Collider other)
    {
        HideAnim.state = false;
        animator.SetBool("Hiding", HideAnim.state);

    }
}