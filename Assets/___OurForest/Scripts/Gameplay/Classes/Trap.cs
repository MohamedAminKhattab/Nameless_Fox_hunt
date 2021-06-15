using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Item
{
 public Trap()
    {
        Itemcount = 1;
        Craftable = true;
        Fooditem = false;
        Healthincrease = 0;
        WoodNeeded = 1;
        RockNeeded = 1;
        VinesNeeded = 0;
        Durability = 20;
        Type = ItemTypes.Trap;
    }
}
