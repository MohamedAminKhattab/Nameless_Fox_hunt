using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    [SerializeField] BoolSO hasTarget;
    [SerializeField] TransformSO enemyTransform;
    private void Start()
    {
        hasTarget.state = false;
    }
    public void EventPointerdown()
    {
        Debug.LogWarning("CheckingTile");
        if (/*Can_Trap == true&&*/hasTarget.state == false)
        {
            enemyTransform.value = transform;
            hasTarget.state = true;
        }
    }
}
