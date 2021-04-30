using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    FloatSO speedSO;
    void Start()
    {
        speedSO.value = speed;
    }

    void Update()
    {
        
    }
}
