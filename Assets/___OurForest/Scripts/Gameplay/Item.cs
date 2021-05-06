using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemTypes
{
    Rock,Wood,Vine,Trap,Weapon,Food
}
public abstract class Item:MonoBehaviour
{
    //-ItemType: Enum
    //-ItemCount: int 
    //-Craftable: bool
    //-fooditem:bool
    //-healthincrease:int
    //-Woodneeded: int
    //-Rockneeded: int
    //-Vinesneeded: int


    private int itemcount;
    private bool craftable;
    private bool fooditem;
    private int healthincrease;
    private int woodNeeded;
    private int rockNeeded;
    private int vinesNeeded;
    private float durability;
    private ItemTypes type;
    [SerializeField] InventorySO inventory;

    public int Itemcount { get => itemcount; set => itemcount = value; }
    public bool Craftable { get => craftable; }
    public bool Fooditem { get => fooditem; }
    public int Healthincrease { get => healthincrease; }
    public int WoodNeeded { get => woodNeeded; }
    public int RockNeeded { get => rockNeeded; }
    public int VinesNeeded { get => vinesNeeded; }
    public ItemTypes Type { get => type; }
    public float Durability { get => durability;  set => durability = value; }
    public abstract void DestroyItem();

    public abstract void Craft();
}