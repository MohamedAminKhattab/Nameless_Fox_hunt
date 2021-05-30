using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetingEnemy : MonoBehaviour
{
    [SerializeField] TransformSO enemytargetSO;
    [SerializeField] BoolSO hasEnemyTarget;
    private void Start()
    {
        enemytargetSO.value = null;
        hasEnemyTarget.state = false;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            if (Input.touchCount > 0)
            {
                foreach (var touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    Physics.Raycast(ray, out RaycastHit hit);
                    if (hasEnemyTarget.state == false && FCompareTag(hit.collider.gameObject.tag))
                    {
                        enemytargetSO.value = hit.transform;
                        hasEnemyTarget.state = true;
                        Debug.LogWarning($"{enemytargetSO.value.gameObject.name}=>{enemytargetSO.value.position}");
                    }
                }
            }
        }
    }

    private bool FCompareTag(string tag)
    {
        return tag switch
        {
            "enemy" => true,
            _ => false
        };
    }
}
