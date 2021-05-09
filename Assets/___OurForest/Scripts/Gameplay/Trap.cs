using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Item
{
 public Trap()
    {
        Itemcount = 0;
        Craftable = true;
        Fooditem = false;
        Healthincrease = 0;
        WoodNeeded = 2;
        RockNeeded = 5;
        VinesNeeded = 1;
        Durability = 20;
        Type = ItemTypes.Trap;
    }
}
