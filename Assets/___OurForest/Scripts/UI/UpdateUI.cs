using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] TMP_Text hunterCount;
    [SerializeField] TMP_Text woodCount;
    [SerializeField] TMP_Text rockCount;
    [SerializeField] TMP_Text vinesCount;
    [SerializeField] TMP_Text trapsCount;
    [SerializeField] TMP_Text weaponsCount;
    [SerializeField] GameManager _GM;
    private void Start()
    {
        rockCount.text = _GM.Inv.GetItemCount(ItemTypes.Rock).ToString();
        woodCount.text = _GM.Inv.GetItemCount(ItemTypes.Wood).ToString();
        vinesCount.text = _GM.Inv.GetItemCount(ItemTypes.Vine).ToString();
        trapsCount.text = _GM.Inv.GetItemCount(ItemTypes.Trap).ToString();
        weaponsCount.text = _GM.Inv.GetItemCount(ItemTypes.Weapon).ToString();
    }
    public void UpdateInGameUI()
    {
        rockCount.text = _GM.Inv.GetItemCount(ItemTypes.Rock).ToString();    
        woodCount.text = _GM.Inv.GetItemCount(ItemTypes.Wood).ToString();    
        vinesCount.text = _GM.Inv.GetItemCount(ItemTypes.Vine).ToString();    
        trapsCount.text = _GM.Inv.GetItemCount(ItemTypes.Trap).ToString();    
        weaponsCount.text = _GM.Inv.GetItemCount(ItemTypes.Weapon).ToString();    
    }
    private void Update()
    {
        UpdateInGameUI();
    }
}