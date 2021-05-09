using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public int Capacity;
    readonly int maxCapacity = 50;
    List<Item> itemlist;
 public Inventory()
    {
        itemlist = new List<Item>(maxCapacity);
        //itemlist.Clear();
        itemlist.Add(new Rock());
        itemlist.Add(new Wood());
        itemlist.Add(new Food());
        itemlist.Add(new Vine());
        itemlist.Add(new Trap() { Itemcount=2});
        itemlist.Add(new Weapon());
    }
    public int GetItemCount(ItemTypes type)
    {
        int itemcount = 0;
        if (itemlist.Count > 0)
        {
            foreach (var item in itemlist)
            {
                if (item.Type == type)
                {
                    itemcount = item.Itemcount;
                    return itemcount;
                }
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