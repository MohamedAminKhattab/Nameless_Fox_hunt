using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureOrFetch : MonoBehaviour
{
    [SerializeField] EventSO foxlureevent;
    [SerializeField] EventSO foxfetchevent;
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
    }

}
