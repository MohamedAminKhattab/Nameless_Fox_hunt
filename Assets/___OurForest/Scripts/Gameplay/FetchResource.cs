using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchResource : MonoBehaviour
{
    Rock r;
    Vine v;
    [SerializeField]
    BoolSO collectResource;
    [SerializeField] TransformSO target;
    [SerializeField] BoolSO hastarget;
    float timerCount = 0.1f;

    void Start()
    {
        if(gameObject.tag=="Vine")
        {
            v = new Vine();
        }
        else if(gameObject.tag == "Rock")
        {
        r = new Rock();
        }
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
    public void EventPointerDown()
    {
        if(hastarget.state==false)
        {
            target.value = transform;
            hastarget.state = true;
        }
    }
}
