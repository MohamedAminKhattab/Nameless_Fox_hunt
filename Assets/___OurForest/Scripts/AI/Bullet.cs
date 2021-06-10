using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
            return;
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("enemy"))
            return;
        Destroy(gameObject);

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
