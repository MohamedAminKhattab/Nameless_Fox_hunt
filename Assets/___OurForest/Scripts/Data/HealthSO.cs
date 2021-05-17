using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealthSO", menuName = "Data/SO/HealthSO")]

public class HealthSO : ScriptableObject
{
    public float initialHealth;
    public float currentHealth;
    public float CurrentHealth { get { return currentHealth; } }


    public void ApplyDamage(float Damage)
    {
        currentHealth -= Damage;
        //if(currentHealth<=0)
        //Call event listener for player death
    }
    public void Healing(float healingPoints)
    {
        currentHealth -= healingPoints;
        if (currentHealth > initialHealth)
            currentHealth = initialHealth;
    }
}
