using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSaveSO", menuName = "Data/SO/PlayerSaveSO")]
public class PlayerSaveSO : ScriptableObject
{
    public int LastClearedLevel { get => lastClearedLevel; set => lastClearedLevel = value; }
    [SerializeField] private int lastClearedLevel;
    [SerializeField] private float playerhealth;
    [SerializeField] private float foxhealth;
    [SerializeField] private List<Item> inventoryItems = new List<Item>();

    public void Save(float _playerHealth, float _foxHealth, List<Item> _items, bool _levelCleared)
    {
        playerhealth = _playerHealth;
        foxhealth = _foxHealth;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Assets/___OurForest/Resources/PlayerInv.txt");
        InventoryData data = new InventoryData();

        data.foodcount = _items.Find(a => a.Type == ItemTypes.Food).Itemcount;
        data.woodcount = _items.Find(a => a.Type == ItemTypes.Wood).Itemcount;
        data.rockcount = _items.Find(a => a.Type == ItemTypes.Rock).Itemcount;
        data.vinecount = _items.Find(a => a.Type == ItemTypes.Vine).Itemcount;
        data.weaponcount = _items.Find(a => a.Type == ItemTypes.Weapon).Itemcount;
        data.trapcount = _items.Find(a => a.Type == ItemTypes.Trap).Itemcount;
        bf.Serialize(file, data);
        file.Close();
        if (_levelCleared)
        {
            lastClearedLevel++;
        }
    }
    public void Load(float _playerhealth, float _foxHealth, List<Item> _items, int _lastLevelCleared)
    {
        _playerhealth = playerhealth;
        _foxHealth = foxhealth;
        if (File.Exists("Assets/___OurForest/Resources/PlayerInv.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/PlayerInv.txt", FileMode.Open);
            InventoryData data = new InventoryData();
            data = (InventoryData)bf.Deserialize(file);
            _items.Find(a => a.Type == ItemTypes.Food).Itemcount = data.foodcount;
            _items.Find(a => a.Type == ItemTypes.Wood).Itemcount = data.woodcount;
            _items.Find(a => a.Type == ItemTypes.Rock).Itemcount = data.rockcount;
            _items.Find(a => a.Type == ItemTypes.Vine).Itemcount = data.vinecount;
            _items.Find(a => a.Type == ItemTypes.Weapon).Itemcount = data.weaponcount;
            _items.Find(a => a.Type == ItemTypes.Trap).Itemcount = data.trapcount;
            file.Close();
        }
        else
        {
            Debug.LogError("File not found");
        }
        _lastLevelCleared = lastClearedLevel;
    }
}

