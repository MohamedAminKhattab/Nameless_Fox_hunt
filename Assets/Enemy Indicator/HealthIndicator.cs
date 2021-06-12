using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] HealthSO health;
    Vector3 healthBarPos;


    void Update()
    {
        healthBarPos = Camera.main.WorldToScreenPoint(transform.position);
        healthBar.value = (int)health.currentHealth;
        healthBar.transform.position = healthBarPos + new Vector3(0, 90, 0);
    }
}
