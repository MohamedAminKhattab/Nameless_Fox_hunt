using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Trapping : MonoBehaviour
{

    [SerializeField] BoolSO needTrap;
    [SerializeField] Vector3SO trapLocation;
    [SerializeField] GameObject trapPrefab;
    [SerializeField] GameManager _GM;
    // Start is called before the first frame update
    void Start()
    {
        trapLocation.value = Vector3.zero;
        needTrap.state = false;
    }
    public void NeedTrap()
    {
        if (needTrap.state == true && _GM.Inv.GetItemCount(ItemTypes.Trap) > 0)
        {
            Instantiate(trapPrefab, trapLocation.value, Quaternion.identity);
            _GM.Inv.UseItem(ItemTypes.Trap, 1);
            trapLocation.value = Vector3.zero;
            needTrap.state = false;
        }
    }
}
