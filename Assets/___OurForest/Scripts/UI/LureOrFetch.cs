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
            Debug.Log("foxfetch");
        }
        if(enemytarget.value)
        {
            foxlureevent.Raise();
            Debug.Log("foxlure");
        }
        if(enemytarget.value==null&&target.value==null)
        {
            foxfleeevent.Raise();
            Debug.Log("foxflee");
        }
    }

}
