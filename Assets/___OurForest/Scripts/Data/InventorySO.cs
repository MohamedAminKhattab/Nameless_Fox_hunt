using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/SO/InventorySO", fileName = "InventorySO")]
public class InventorySO : ScriptableObject
{
    public int Capacity;
    int maxCapacity = 50;
    public List<Item> itemlist;
    UpdateUI updater;
 
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
            Debug.Log(itemlist.Count);
            foreach (var item in itemlist)
            {
                Debug.Log("Add");
                if (item.Type == type)
                {
                    item.Itemcount += 1;
                    Capacity += 1;
                    //updater.UpdateInGameUI();
                    Debug.Log("Item Added");
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
                   // updater.UpdateInGameUI();
                }
            }
        }
        return useSuccess;
    }
}
