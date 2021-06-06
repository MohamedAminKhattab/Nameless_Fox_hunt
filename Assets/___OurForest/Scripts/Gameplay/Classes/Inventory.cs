using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class Inventory
{
    public int Capacity;
    readonly int maxCapacity = 50;
    List<Item> itemlist;
    public EventHandler OnInvItemsChangeHandler;

    public int MaxCapacity => maxCapacity;

    public List<Item> Itemlist { get => itemlist; set => itemlist = value; }

    public Inventory()
    {
        itemlist = new List<Item>(maxCapacity);
        itemlist.Add(new Rock() { Itemcount=0});
        itemlist.Add(new Wood() { Itemcount = 0 });
        itemlist.Add(new Weapon() { Itemcount = 0 });
        itemlist.Add(new Vine() { Itemcount = 0 });
        itemlist.Add(new Trap() { Itemcount = 0 });
        itemlist.Add(new Food() { Itemcount = 0 });
    }
    public int GetWoodneeded(ItemTypes type)
    {
        int woodneeded=0;
        switch (type)
        {
            case ItemTypes.Trap:
                Trap t = new Trap();
                woodneeded = t.WoodNeeded;
                break;
            case ItemTypes.Weapon:
                Weapon  w = new Weapon();
                woodneeded = w.WoodNeeded;
                break;
            default:
                break;
        }
        return woodneeded;
    }
    public int GetRockneeded(ItemTypes type)
    {
        int rockneeded = 0;
        switch (type)
        {
            case ItemTypes.Trap:
                Trap t = new Trap();
                rockneeded = t.RockNeeded;
                break;
            case ItemTypes.Weapon:
                Weapon w = new Weapon();
                rockneeded = w.RockNeeded;
                break;
            default:
                break;
        }
        return rockneeded;
    }
    public int GetVineneeded(ItemTypes type)
    {
        int vineneeded = 0;
        switch (type)
        {
            case ItemTypes.Trap:
                Trap t = new Trap();
                vineneeded = t.VinesNeeded;
                break;
            case ItemTypes.Weapon:
                Weapon w = new Weapon();
                vineneeded = w.VinesNeeded;
                break;
            default:
                break;
        }
        return vineneeded;
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
        OnInvItemsChangeHandler?.Invoke(this, EventArgs.Empty);
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
        OnInvItemsChangeHandler?.Invoke(this, EventArgs.Empty);
        return useSuccess;
    }
    public void Craft(Item item )
    {
        if(item.Craftable==true)
        {
            if(GetItemCount(ItemTypes.Wood)>=item.WoodNeeded&& GetItemCount(ItemTypes.Rock) >= item.RockNeeded && GetItemCount(ItemTypes.Vine) >= item.VinesNeeded)
            {
               if(UseItem(ItemTypes.Wood,item.WoodNeeded)&& UseItem(ItemTypes.Rock, item.RockNeeded) && UseItem(ItemTypes.Vine, item.VinesNeeded) )
                {
                    AddItem(item.Type);
                }
            }
        }
    }
}