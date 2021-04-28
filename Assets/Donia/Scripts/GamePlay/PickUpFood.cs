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
        pickUpFood.state = false;  
    }
     void Update()
    {
        if (pickUpFood.state)
            CanPickUpFood();
    }
    public void CanPickUpFood()
    {
        Debug.Log("In");
        bool canGet = transform.position.magnitude - player.transform.position.magnitude <= range;
        if (canGet)
        {
            //Add to inventory
            pickUpFood.state= false;
            Destroy(this.gameObject);
        }
    }
}
