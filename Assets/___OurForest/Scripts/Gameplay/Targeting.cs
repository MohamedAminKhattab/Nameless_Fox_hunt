using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Targeting : MonoBehaviour
{
    [SerializeField] TransformSO targetSO;
    [SerializeField] BoolSO hasTarget;
    [SerializeField] IntegerSO selectedLevel;
    private void Start()
    {
        targetSO.value = null;
        hasTarget.state = false;
    }
    private void Update()
    {
        if (SceneManager.GetSceneByName($"Level {selectedLevel.value}").isLoaded)
        {
            if (Input.touchCount > 0)
            {
                foreach (var touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hasTarget.state == false && FCompareTag(hit.collider.gameObject.tag))
                        {
                            targetSO.value = hit.transform;
                            hasTarget.state = true;
                            //Debug.LogWarning($"{targetSO.value.gameObject.name}=>{targetSO.value.position}");
                        }
                    }
                }
            }
        }
    }

    private bool FCompareTag(string tag)
    {
        return tag switch
        {
            "Wood" => true,
            "Rock" => true,
            "Vine" => true,
            "Food" => true,
            _ => false
        };
    }
}