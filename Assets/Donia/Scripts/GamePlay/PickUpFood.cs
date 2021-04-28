using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFood : MonoBehaviour
{
    [SerializeField]
    float range;
    [SerializeField]
    Transform player;
    [SerializeField]
    BoolSO pickUpFood;
     void Start()
    {
        pickUpFood.Bool_SO = false;  
    }
     void Update()
    {
        if (pickUpFood.Bool_SO)
            CanPickUpFood();
    }
    public void CanPickUpFood()
    {
        Debug.Log("In");
        bool canGet = transform.position.magnitude - player.transform.position.magnitude <= range;
        if (canGet)
        {
            //Add to inventory
            pickUpFood.Bool_SO = false;
            Destroy(this.gameObject);
        }
    }
}
