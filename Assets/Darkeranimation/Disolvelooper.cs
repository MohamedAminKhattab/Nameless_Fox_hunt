using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolvelooper : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer Dis;

    void Start()
    {
        Dis = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

      Dis.material.SetFloat("_Disolver", Mathf.Sin(Time.time));
    }
}
