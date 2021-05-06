using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    private int itemcount = 1;
    private bool craftable = false;
    private bool fooditem = true;
    private int healthincrease =10;
    private int woodNeeded = 0;
    private int rockNeeded = 0;
    private int vinesNeeded = 0;
    private float durability = 0.0f;
    private ItemTypes type = ItemTypes.Food;
    [SerializeField] InventorySO inventory;
    public override void Craft()
    {
    }

    public override void DestroyItem()
    {
    }
}