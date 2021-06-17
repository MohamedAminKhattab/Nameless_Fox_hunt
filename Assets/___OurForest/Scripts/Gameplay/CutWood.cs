using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWood : MonoBehaviour
{
    Wood wood;
    [SerializeField]
    BoolSO cutWood;
    float timerCount = 0.1f;
    [SerializeField] TransformSO target;
    [SerializeField] BoolSO hastarget;
    void Start()
    {
        wood = new Wood();
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
    public void EventPointerDown()
    {
        if (hastarget.state == false)
        {
            target.value = transform;
            hastarget.state = true;
        }
    }
}
