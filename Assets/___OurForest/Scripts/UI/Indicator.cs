using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public static int Count=0;
    readonly private int max = 5;
    private void Start()
    {
        if(Count<max)
        {
            Count++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}