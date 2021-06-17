using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFood : MonoBehaviour
{
    Food f;
    [SerializeField]
    BoolSO pickUpFood;
    float timerCount = 0.1f;
    //[SerializeField]
    //BoolSO canPick;
    [SerializeField] TransformSO target;
    [SerializeField] BoolSO hastarget;
    void Start()
    {
        f = new Food();
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
    public void EventPointerDown()
    {
        if (hastarget.state == false)
        {
            target.value = transform;
            hastarget.state = true;
        }
    }
}
