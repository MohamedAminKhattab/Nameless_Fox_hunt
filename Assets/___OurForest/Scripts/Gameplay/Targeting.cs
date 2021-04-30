using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] TransformSO targetSO;
    [SerializeField] LayerMask Mask;
    private void Start()
    {
        targetSO.value = null;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit,Mask))
                {
                    targetSO.value = hit.transform;
                    Debug.LogWarning($"{targetSO.value.gameObject.name}=>{targetSO.value.position}");
                }
            }
        }
    }
}