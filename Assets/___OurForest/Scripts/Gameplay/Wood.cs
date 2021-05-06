using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item
{
    private int itemcount = 1;
    private bool craftable = false;
    private bool fooditem = false;
    private int healthincrease = 0;
    private int woodNeeded = 0;
    private int rockNeeded = 0;
    private int vinesNeeded = 0;
    private float durability = 0.0f;
    private ItemTypes type = ItemTypes.Wood;
    [SerializeField] InventorySO inventory;
    public override void Craft()
    {
    }

    public override void DestroyItem()
    {
    }
}