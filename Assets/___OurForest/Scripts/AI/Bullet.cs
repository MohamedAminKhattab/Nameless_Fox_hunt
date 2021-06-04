using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("enemy"))
            return;
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag.Equals("enemy"))
            return;
        Destroy(gameObject);

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
