using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealthSO", menuName = "Data/SO/HealthSO")]

public class HealthSO : ScriptableObject
{
    public float initialHealth;
    public float currentHealth;
    public float CurrentHealth { get { return currentHealth; } }

    void OnEnable()
    {
        currentHealth = initialHealth;
    }
    public void ApplyDamage(float Damage,EventSO Death)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Death.Raise();
            //Debug.Log("DIED");
        }
           
    }
    public void Healing(float healingPoints)
    {
        currentHealth += healingPoints;
        if (currentHealth > initialHealth)
            currentHealth = initialHealth;
    }
}
