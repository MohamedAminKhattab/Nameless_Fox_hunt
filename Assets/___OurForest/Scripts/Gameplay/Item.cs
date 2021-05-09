using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemTypes
{
    Rock,Wood,Vine,Trap,Weapon,Food
}
public abstract class Item
{
    private int itemcount;
    private bool craftable;
    private bool fooditem;
    private int healthincrease;
    private int woodNeeded;
    private int rockNeeded;
    private int vinesNeeded;
    private float durability;
    private ItemTypes type;

    public int Itemcount { get => itemcount; set => itemcount = value; }
    public bool Craftable { get => craftable; set => craftable = value; }
    public bool Fooditem { get => fooditem; set => fooditem = value; }
    public int Healthincrease { get => healthincrease; set => healthincrease = value; }
    public int WoodNeeded { get => woodNeeded; set => woodNeeded = value; }
    public int RockNeeded { get => rockNeeded; set => rockNeeded = value; }
    public int VinesNeeded { get => vinesNeeded; set => vinesNeeded = value; }
    public ItemTypes Type { get => type; set=> type=value; }
    public float Durability { get => durability;  set => durability = value; }
}