using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemTypes
{
    Rock,Wood,Vine,Trap,Weapon,Food
}
public class Item
{
    //    -ItemType: Enum
    //-ItemCount: int 
    //-Craftable: bool
    //-Woodneeded: int
    //-Rockneeded: int
    //-Vinesneeded: int

    int itemcount;
    bool craftable;
    int woodNeeded;
    int rockNeeded;
    int vinesNeeded;
 public void craft()
    {
    }
}