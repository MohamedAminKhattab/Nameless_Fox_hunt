using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxInventory : MonoBehaviour
{
    [SerializeField] GameManager _gm;
    [SerializeField] TransformSO target;
    [SerializeField] BoolSO hastarget;
    [SerializeField] HealthSO foxHealth;
    public GameManager Gm { get => _gm; set => _gm = value; }

    private void Start()
    {
        foxHealth.initialHealth = 100;
        foxHealth.currentHealth = 100;
        foxHealth.dead = false;
       //
       //
       //Debug.LogWarning(_gm);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target.value)
        {

            switch (other.gameObject.tag)
            {
                case "Food":
                    _gm.Inv.AddItem(ItemTypes.Food);
                    other.gameObject.SetActive(false);

                    break;
                case "Wood":
                    _gm.Inv.AddItem(ItemTypes.Wood);
                    other.gameObject.SetActive(false);
                    break;
                case "Rock":
                    _gm.Inv.AddItem(ItemTypes.Rock);
                    other.gameObject.SetActive(false);
                    break;
                case "Vine":
                    _gm.Inv.AddItem(ItemTypes.Vine);
                    other.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
    public void Heal()
    {
        //Debug.LogWarning(_gm);
        if (_gm.Inv.GetItemCount(ItemTypes.Food)>0)
        {
                Debug.Log($"Fox"+foxHealth.currentHealth);
            if(foxHealth.currentHealth<foxHealth.initialHealth)
            {
                Debug.Log($"Fox" + foxHealth.currentHealth);
                _gm.Inv.UseItem(ItemTypes.Food, 1);
                foxHealth.Healing(10);
            }
        }
    }
}