using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Food : Item
{
    public Food()
    {
        Itemcount = 1;
        Craftable = false;
        Fooditem = true;
        Healthincrease = 10;
        WoodNeeded = 0;
        RockNeeded = 0;
        VinesNeeded = 0;
        Durability = 0.0f;
        Type = ItemTypes.Food;
    }
}