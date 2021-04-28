using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] GameObjectSO targetGOSO;
    private void Start()
    {
        targetGOSO._gameObject = null;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                    targetGOSO._gameObject=(GameObject)hit.transform.gameObject;
                print(targetGOSO._gameObject.name);
            }
        }
    }
}