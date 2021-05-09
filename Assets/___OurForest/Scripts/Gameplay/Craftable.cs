using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Craftable : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemTypes type;
    [SerializeField] GameManager _GM;
    [SerializeField] TMP_Text woodNeeded;
    [SerializeField] TMP_Text rockNeeded;
    [SerializeField] TMP_Text vinesNeeded;
    [SerializeField] Button craft;
    public void SetTypeToWeapon()
    {
        type = ItemTypes.Weapon;
    }
    public void SetTypeToTrap()
    {
        type = ItemTypes.Trap;
    }
    public void ShowRequired()
    {
        woodNeeded.text = _GM.Inv.GetWoodneeded(type).ToString();
        rockNeeded.text = _GM.Inv.GetRockneeded(type).ToString();
        vinesNeeded.text = _GM.Inv.GetVineneeded(type).ToString();
    }
    public void ToggleCraftButton()
    {
        if(_GM.Inv.GetItemCount(ItemTypes.Wood) >= _GM.Inv.GetWoodneeded(type)&& _GM.Inv.GetItemCount(ItemTypes.Rock) >= _GM.Inv.GetRockneeded(type)&& _GM.Inv.GetItemCount(ItemTypes.Vine) >= _GM.Inv.GetVineneeded(type))
        {
            craft.interactable = true;
        }
        else
        {
            craft.interactable = false;
        }
    }
    public void Craft()
    {
        switch (type)
        {
            case ItemTypes.Trap:
                _GM.Inv.Craft(new Trap());
                break;
            case ItemTypes.Weapon:
                _GM.Inv.Craft(new Weapon());
                break;
            default:
                break;
        }
    }
}
