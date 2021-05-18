using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] TransformSO targetSO;
    [SerializeField] LayerMask mask;
    [SerializeField] RectTransform joystickField;
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
                Vector3 touchposition = new Vector3(touch.position.x, touch.position.y,0.0f);
                Ray ray = Camera.main.ScreenPointToRay(touchposition);
                if (Physics.Raycast(ray, out hit,mask)&&hasTarget.state==false&&(hit.collider.gameObject.tag != "Ground"|| hit.collider.gameObject.tag != "Walkable") && !joystickField.rect.Contains(touch.position))
                {
                    targetSO.value = hit.transform;
                    hasTarget.state = true;
                    Debug.LogWarning($"{targetSO.value.gameObject.name}=>{targetSO.value.position}");
                }
            }
        }
    }
}