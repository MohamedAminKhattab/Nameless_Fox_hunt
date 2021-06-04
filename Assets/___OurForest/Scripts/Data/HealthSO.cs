using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealthSO", menuName = "Data/SO/HealthSO")]

public class HealthSO : ScriptableObject
{
    public float initialHealth;
    public float currentHealth;
    public EventSO Death;

    public bool dead;
    public float CurrentHealth { get { return currentHealth; } }

    void OnEnable()
    {
        currentHealth = initialHealth;
        dead = false;
    }
    public void ApplyDamage(float Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            dead = true;
           // Debug.Log("DEAD");
        }

    }
    public void Healing(float healingPoints)
    {
        currentHealth += healingPoints;
        if (currentHealth > initialHealth)
            currentHealth = initialHealth;
    }
}