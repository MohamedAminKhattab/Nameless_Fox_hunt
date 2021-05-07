using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFood : MonoBehaviour
{
    [SerializeField]
    BoolSO pickUpFood;
    float timerCount = 0.1f;
    //[SerializeField]
    //BoolSO canPick;
    void Start()
    {
        pickUpFood.state = false;
        //canPick.state = false;
    }
    void Update()
    {
        timerCount -= Time.deltaTime;
        if (timerCount <= 0)
        {
            pickUpFood.state = false;
            timerCount = 0.1f;
        }
    }
 
}
