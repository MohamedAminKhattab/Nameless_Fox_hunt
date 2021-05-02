using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] TransformSO targetSO;
    [SerializeField] LayerMask Mask;
    [SerializeField] BoolSO hasTarget;
    private void Start()
    {
        targetSO.value = null;
        hasTarget.state =false;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit,Mask)&&hasTarget.state==false&&hit.collider.gameObject.tag!="Ground")
                {
                    targetSO.value = hit.transform;
                    hasTarget.state = true;
                    Debug.LogWarning($"{targetSO.value.gameObject.name}=>{targetSO.value.position}");
                }
            }
        }
    }
}