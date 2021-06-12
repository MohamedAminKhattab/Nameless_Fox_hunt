using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureOrFetch : MonoBehaviour
{
    [SerializeField] EventSO foxlureevent;
    [SerializeField] EventSO foxfetchevent;
    [SerializeField] EventSO foxfleeevent;
    [SerializeField] TransformSO enemytarget;
    [SerializeField] TransformSO target;
    public void RaiseEvent()
    {
        if(target.value)
        {
            foxfetchevent.Raise();
            //Debug.Log("foxfetch");
        }
        else if(enemytarget.value)
        {
            foxlureevent.Raise();
           // Debug.Log("foxlure");
        }
        else
        {
            foxfleeevent.Raise();
           // Debug.Log("foxflee");
        }
    }

}
