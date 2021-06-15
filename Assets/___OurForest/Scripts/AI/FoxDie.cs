using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDie : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject ragdoll;
    public void foxdying()
    {
        animator.enabled = false;
        ragdoll.SetActive(true);
    }
}
