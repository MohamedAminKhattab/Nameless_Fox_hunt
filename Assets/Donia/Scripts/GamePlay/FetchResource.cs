using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchResource : MonoBehaviour
{
    [SerializeField]
    BoolSO collectResource;
    float timerCount = 0.1f;

    void Start()
    {
        collectResource.state = false;
    }
    void Update()
    {
        timerCount -= Time.deltaTime;
        if (timerCount <= 0)
        {
            collectResource.state = false;
            timerCount = 0.1f;
        }
    }
}
