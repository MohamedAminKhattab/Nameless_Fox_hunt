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
        }
        if(enemytarget.value)
        {
            foxlureevent.Raise();
        }
        if(enemytarget.value==null&&target.value==null)
        {
            foxfleeevent.Raise();
        }
    }

}
