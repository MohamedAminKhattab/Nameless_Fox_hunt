using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolvelooper1 : MonoBehaviour
{
    [SerializeField] MeshRenderer Dis;

    void Start()
    {
        Dis = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

      Dis.material.SetFloat("_Fogintesity", Mathf.Sin(Time.time));
    }
}
