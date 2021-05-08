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
    [SerializeField] InventorySO inventory;
    private void Start()
    {
        weaponsCount.text = inventory.GetItemCount(ItemTypes.Weapon).ToString();
        trapsCount.text = inventory.GetItemCount(ItemTypes.Trap).ToString();
        vinesCount.text = inventory.GetItemCount(ItemTypes.Vine).ToString();
        woodCount.text = inventory.GetItemCount(ItemTypes.Wood).ToString();
        rockCount.text = inventory.GetItemCount(ItemTypes.Rock).ToString();
    }
    public void UpdateInGameUI()
    {
        weaponsCount.text = inventory.GetItemCount(ItemTypes.Weapon).ToString();    
        trapsCount.text = inventory.GetItemCount(ItemTypes.Trap).ToString();    
        vinesCount.text = inventory.GetItemCount(ItemTypes.Vine).ToString();    
        woodCount.text = inventory.GetItemCount(ItemTypes.Wood).ToString();    
        rockCount.text = inventory.GetItemCount(ItemTypes.Rock).ToString();    
    }
    private void Update()
    {
        UpdateInGameUI();
    }
}
