using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Weapon()
    {
        Itemcount = 0;
        Craftable = true;
        Fooditem = false;
        Healthincrease = 0;
        WoodNeeded = 1;
        RockNeeded = 5;
        VinesNeeded = 1;
        Durability = 30;
        Type = ItemTypes.Weapon;
    }
}
