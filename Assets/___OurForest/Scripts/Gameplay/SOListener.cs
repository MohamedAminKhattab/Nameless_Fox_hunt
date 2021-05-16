using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SOListener : MonoBehaviour
{
    public EventSO eventSo;

    public UnityEvent OnRaise;

    public void OnEventRaised()
    {
        OnRaise.Invoke();
    }

    private void OnEnable()
    {
        eventSo.RegisterListener(this);
    }
    private void OnDisable()
    {
        eventSo.UnregisterListener(this);
    }
}
