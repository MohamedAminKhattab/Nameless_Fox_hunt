using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBehaviour : MonoBehaviour
{
    Trap t;
    [SerializeField] EventSO EnemyDied1;
    [SerializeField] EventSO EnemyDied2;
    [SerializeField] EventSO EnemyDied3;
    [SerializeField] EventSO EnemyDied4;
    [SerializeField] Animator _animator;
    [SerializeField] BoxCollider _collider;
    private void Start()
    {
        t = new Trap();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<CapsuleCollider>().enabled = false;
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
                case "Point4":
                    EnemyDied4.Raise();
                    break;
                default:
                    break;
            }
            _collider.enabled = false;
            _animator.SetTrigger("Active");
        }
    }
}
