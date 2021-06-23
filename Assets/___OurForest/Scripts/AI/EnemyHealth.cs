using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] EventSO enemyDeath;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("bullet"))
        {
            health -= 20;
            //Debug.Log(health);
            if (health <= 1)
                this.gameObject.SetActive(false);
        }
    }
    
}
