using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Item
{
    public Rock()
    {
        Itemcount = 0;
        Craftable = false;
        Fooditem = false;
        Healthincrease = 0;
        WoodNeeded = 0;
        RockNeeded = 0;
        VinesNeeded = 0;
        Durability = 0.0f;
        Type = ItemTypes.Rock;
    } 
}