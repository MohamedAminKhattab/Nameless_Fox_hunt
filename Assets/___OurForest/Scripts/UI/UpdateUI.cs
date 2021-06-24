using System.Collections;
using System.Collections.Generic;
using System;
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
    [SerializeField] TMP_Text FoodCount;
    [SerializeField] GameManager _GM;

    public GameManager GM { get => _GM; set => _GM = value; }

    private void Awake()
    {
        UpdateHunterCount();
    }
    private void OnDisable()
    {
        UpdateHunterCount();
    }
    private void OnEnable()
    {
        UpdateHunterCount();
    }
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        rockCount.text = _GM.Inv.GetItemCount(ItemTypes.Rock).ToString();
        woodCount.text = _GM.Inv.GetItemCount(ItemTypes.Wood).ToString();
        vinesCount.text = _GM.Inv.GetItemCount(ItemTypes.Vine).ToString();
        trapsCount.text = _GM.Inv.GetItemCount(ItemTypes.Trap).ToString();
        weaponsCount.text = _GM.Inv.GetItemCount(ItemTypes.Weapon).ToString();
        FoodCount.text = _GM.Inv.GetItemCount(ItemTypes.Food).ToString();
        hunterCount.text = _GM.CurrentTroopCount.ToString();
        _GM.Inv.OnInvItemsChangeHandler +=UpdateInGameUI;
        UpdateHunterCount();
    }
    public void UpdateInGameUI(object sender,EventArgs e)
    {
        rockCount.text = _GM.Inv.GetItemCount(ItemTypes.Rock).ToString();    
        woodCount.text = _GM.Inv.GetItemCount(ItemTypes.Wood).ToString();    
        vinesCount.text = _GM.Inv.GetItemCount(ItemTypes.Vine).ToString();    
        trapsCount.text = _GM.Inv.GetItemCount(ItemTypes.Trap).ToString();    
        weaponsCount.text = _GM.Inv.GetItemCount(ItemTypes.Weapon).ToString();
        FoodCount.text = _GM.Inv.GetItemCount(ItemTypes.Food).ToString();
    }
    public void UpdateHunterCount()
    {
        hunterCount.text = _GM.CurrentTroopCount.ToString();
    }
    public void WaitforText()
    {
        StartCoroutine(Wait());
    }
     IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
