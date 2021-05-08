using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/SO/InventorySO", fileName = "InventorySO")]
public class InventorySO : ScriptableObject
{
    public int Capacity;
    [SerializeField]int maxCapacity = 50;
    public List<Item> itemlist; 
    private void OnEnable()
    {
        AddItem(ItemTypes.Wood);
        AddItem(ItemTypes.Rock);
        AddItem(ItemTypes.Vine);
        AddItem(ItemTypes.Weapon);
        AddItem(ItemTypes.Trap);
        AddItem(ItemTypes.Food);
    }
    public int GetItemCount(ItemTypes type)
    {
        int itemcount = 0;
        foreach (var item in itemlist)
        {
            if (item.Type == type)
            {
                itemcount = item.Itemcount;
                return itemcount;
            }
        }
        return itemcount;
    }
    public void AddItem(ItemTypes type)
    {
        if (Capacity < maxCapacity)
        {
            foreach (var item in itemlist)
            {
                if (itemlist.Count > 0)
                {
                    if (item.Type == type)
                    {
                        item.Itemcount += 1;
                        Capacity += 1;
                    }
                }
                else
                {
                    switch (type)
                    {
                        case ItemTypes.Rock:
                            itemlist.Add(new Rock());
                            break;
                        case ItemTypes.Wood:
                            itemlist.Add(new Wood());
                            break;
                        case ItemTypes.Vine:
                            itemlist.Add(new Vine());
                            break;
                        case ItemTypes.Trap:
                            itemlist.Add(new Trap());
                            break;
                        case ItemTypes.Weapon:
                            itemlist.Add(new Weapon());
                            break;
                        case ItemTypes.Food:
                            itemlist.Add(new Food());
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
    public bool UseItem(ItemTypes type, int count)
    {
        bool useSuccess = false;
        foreach (var item in itemlist)
        {
            if (item.Type == type)
            {
                if (item.Itemcount >= count)
                {
                    item.Itemcount -= count;
                    useSuccess = true;
                    Capacity -= 1;
                }
            }
        }
        return useSuccess;
    }
}
