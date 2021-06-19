using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeayth : MonoBehaviour
{
    Animator anim;
    private void Die()
    {
        anim.SetTrigger("die");
    }
    private void OnTriggerEnter(Collider other)
    { 
           

            Die();
        
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
