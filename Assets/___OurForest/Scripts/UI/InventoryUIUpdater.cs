using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUIUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text woodCount;
    [SerializeField] TMP_Text rockCount;
    [SerializeField] TMP_Text vinesCount;
    [SerializeField] TMP_Text trapsCount;
    [SerializeField] TMP_Text weaponsCount;
    [SerializeField] TMP_Text foodCount;
    [SerializeField] GameManager _GM;
    private void Start()
    {
        weaponsCount.text = _GM.Inv.GetItemCount(ItemTypes.Weapon).ToString();
        trapsCount.text = _GM.Inv.GetItemCount(ItemTypes.Trap).ToString();
        vinesCount.text = _GM.Inv.GetItemCount(ItemTypes.Vine).ToString();
        woodCount.text = _GM.Inv.GetItemCount(ItemTypes.Wood).ToString();
        rockCount.text = _GM.Inv.GetItemCount(ItemTypes.Rock).ToString();
        foodCount.text = _GM.Inv.GetItemCount(ItemTypes.Food).ToString();
        _GM.Inv.OnInvItemsChangeHandler += UpdateInGameUI;
    }
    public void UpdateInGameUI(object sender, EventArgs e)
    {
        weaponsCount.text = _GM.Inv.GetItemCount(ItemTypes.Weapon).ToString();
        trapsCount.text = _GM.Inv.GetItemCount(ItemTypes.Trap).ToString();
        vinesCount.text = _GM.Inv.GetItemCount(ItemTypes.Vine).ToString();
        woodCount.text = _GM.Inv.GetItemCount(ItemTypes.Wood).ToString();
        rockCount.text = _GM.Inv.GetItemCount(ItemTypes.Rock).ToString();
        foodCount.text = _GM.Inv.GetItemCount(ItemTypes.Food).ToString();
    }
}
