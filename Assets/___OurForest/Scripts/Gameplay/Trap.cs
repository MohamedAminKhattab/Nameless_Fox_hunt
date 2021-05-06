using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap :Item
{
  
    private int itemcount=0;
    private bool craftable=true;
    private bool fooditem=false;
    private int healthincrease=0;
    private int woodNeeded=2;
    private int rockNeeded=5;
    private int vinesNeeded=1;
    private float durability=20;
    private ItemTypes type=ItemTypes.Trap;
    [SerializeField] InventorySO inventory;
    public override void DestroyItem()
    {
        if (Durability <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public override void Craft()
    {
        if (Craftable && inventory.GetItemCount(ItemTypes.Wood) >= WoodNeeded && inventory.GetItemCount(ItemTypes.Rock) >= RockNeeded && inventory.GetItemCount(ItemTypes.Vine) >= VinesNeeded)
        {
            if (inventory.UseItem(ItemTypes.Wood, WoodNeeded) &&
             inventory.UseItem(ItemTypes.Rock, RockNeeded) &&
             inventory.UseItem(ItemTypes.Vine, VinesNeeded))
            {
                inventory.AddItem(Type);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            switch (Type)
            {
                case ItemTypes.Trap:
                    Durability = 0.0f;
                    DestroyItem();
                    break;
                default:
                    break;
            }
        }
    }
}
