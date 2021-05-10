using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBehaviour : MonoBehaviour
{
    Trap t;
    private void Start()
    {
        t = new Trap();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("enemy"))
            other.gameObject.SetActive(false);
    }
}
