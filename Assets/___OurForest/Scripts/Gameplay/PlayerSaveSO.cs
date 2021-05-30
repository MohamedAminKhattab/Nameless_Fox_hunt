using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSaveSO", menuName = "Data/SO/PlayerSaveSO")]
public class PlayerSaveSO : ScriptableObject
{
    public int LastClearedLevel { get => lastClearedLevel; set => lastClearedLevel = value; }
    [SerializeField] private int lastClearedLevel;
    [SerializeField] private float playerhealth;
    [SerializeField] private float foxhealth;
    [SerializeField] private List<Item> inventoryItems=new List<Item>();

    public void Save(HealthSO _playerHealth, HealthSO _foxHealth, List<Item> _items, bool _levelCleared)
    {
        playerhealth = _playerHealth.currentHealth;
        foxhealth = _foxHealth.currentHealth;
        inventoryItems = _items;
        if (_levelCleared)
        {
            lastClearedLevel++;
        }
    }
    public void Load(HealthSO _playerhealth, HealthSO _foxHealth, List<Item> _items, int _lastLevelCleared)
    {
        _playerhealth.currentHealth = playerhealth;
        _foxHealth.currentHealth = foxhealth;
        _items = inventoryItems;
        _lastLevelCleared = lastClearedLevel;
    }
}
