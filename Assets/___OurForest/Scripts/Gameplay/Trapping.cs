using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Trapping : MonoBehaviour
{

    [SerializeField] BoolSO needTrap;
    [SerializeField] TransformSO trapLocation;
    [SerializeField] Level level;
    [SerializeField] GameObject trapPrefab;
    [SerializeField] GameManager _GM;
    // Start is called before the first frame update
    void Start()
    {
        trapLocation.value = gameObject.transform;
        needTrap.state = false;
    }
    public void NeedTrap()
    {
        level = FindObjectOfType<Level>();
        if (needTrap.state == true && _GM.Inv.GetItemCount(ItemTypes.Trap) > 0&&trapLocation.value.position!= gameObject.transform.position)
        {
            Instantiate(trapPrefab, trapLocation.value.position, Quaternion.identity,level.transform);
            _GM.Inv.UseItem(ItemTypes.Trap, 1);
            trapLocation.value.position = gameObject.transform.position;
            needTrap.state = false;
        }
    }
}
