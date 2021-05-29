using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBehaviour : MonoBehaviour
{
    Trap t;
    [SerializeField] EventSO EnemyDied1;
    [SerializeField] EventSO EnemyDied2;
    [SerializeField] EventSO EnemyDied3;
    private void Start()
    {
        t = new Trap();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            string name = other.GetComponentInParent<SpawnPoint>().name;
            switch (name)
            {
                case "Point1":
                    EnemyDied1.Raise();
                    break;
                case "Point2":
                    EnemyDied2.Raise();
                    break;
                case "Point3":
                    EnemyDied3.Raise();
                    break;
                default:
                    break;
            }
           
            Destroy(this.gameObject);
        }
    }
}
