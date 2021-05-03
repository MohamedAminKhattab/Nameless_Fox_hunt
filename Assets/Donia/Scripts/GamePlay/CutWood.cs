using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWood : MonoBehaviour
{
    [SerializeField]
    BoolSO cutWood;
    float timerCount = 0.1f;
    void Start()
    {
        cutWood.state = false;
    }
    void Update()
    {
        timerCount -= Time.deltaTime;
        if (timerCount <= 0)
        {
            cutWood.state = false;
            timerCount = 0.1f;
        }
    }

}
