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
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("EnemyOntrap");
        if (other.CompareTag("enemy"))
        {
            Debug.LogWarning("EnemyOntrap");
            EnemyDied.Raise();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
