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
        speed = 5.0f;
        speedSO.float_SO = speed;
    }

    void Update()
    {
        
    }
}
