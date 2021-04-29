using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
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
        if(movement.value.z== 1 && velocityZ<0.5)
        {
            velocityZ += Time.deltaTime * acceleration;
        } 
        if(movement.value.z== -1 && velocityZ>-0.5)
        {
            velocityZ += Time.deltaTime * acceleration;
        } 
        if(movement.value.x== 1 && velocityX< 0.5)
        {
            velocityX += Time.deltaTime * acceleration;
        } 
        if(movement.value.x== -1 && velocityX>-0.5)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if ((movement.value.z != 1 || movement.value.z != -1) && velocityZ >0)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if ((movement.value.z != 1|| movement.value.z != -1) && velocityZ <0)
        {
            velocityZ=0;
        }
        if ((movement.value.x != 1 || movement.value.x != -1) && velocityX < 0)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if ((movement.value.x != 1 || movement.value.x != -1) && velocityX >0)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        else if((movement.value.x != 1 || movement.value.x != -1) && velocityX!=0 &&(velocityX>-0.05f && velocityX<-0.05f))
        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }
}
