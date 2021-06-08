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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target.value)
        {

            switch (other.gameObject.tag)
            {
                case "Food":
                   // Debug.LogWarning("Food");
                    _gm.Inv.AddItem(ItemTypes.Food);
                    //target.value = null;
                   // hastarget.state = false;
                   // Destroy(other.gameObject);
                    other.gameObject.SetActive(false);

                    break;
                case "Wood":
                    //Debug.LogWarning("Wood");
                    _gm.Inv.AddItem(ItemTypes.Wood);
                   // target.value = null;
                    //hastarget.state = false;
                    //Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;
                case "Rock":
                    //Debug.LogWarning("Rock");
                    _gm.Inv.AddItem(ItemTypes.Rock);
                  //  target.value = null;
                    //hastarget.state = false;
                    //Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;
                case "Vine":
                   // Debug.LogWarning("Vine");
                    _gm.Inv.AddItem(ItemTypes.Vine);
                   // target.value = null;
                   // hastarget.state = false;
                    // Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }

        }

    }
    public void Heal()
    {
        if(_gm.Inv.GetItemCount(ItemTypes.Food)>0)
        {
            if(foxHealth.currentHealth<foxHealth.initialHealth)
            {
                foxHealth.Healing(10);
            }
        }
    }
}
