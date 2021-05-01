using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] TransformSO targetSO;
    private void Start()
    {
        targetSO.value = null;
            Debug.Log("is Updating");
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("is Touching");
            foreach (var touch in Input.touches)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    targetSO.value = hit.transform;
                    Debug.Log(targetSO.value.gameObject.name);
                }
            }
        }
    }
}