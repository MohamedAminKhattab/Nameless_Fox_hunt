﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBehaviour : MonoBehaviour
{
    Trap t;
    [SerializeField] EventSO EnemyDied;
    private void Start()
    {
        t = new Trap();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            //EnemyDied.Raise();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
            //other.gameObject.SetActive(false);
       
    }
}
