using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    Trap t;
    [SerializeField] EventSO EnemyDied;
    private void Start()
    {
        t = new Trap();
    }
    private void OnCollisionEnter(Collision collision)
    {
            Debug.LogWarning(collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.LogWarning("EnemyOntrap");
            EnemyDied.Raise();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
