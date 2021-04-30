using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    FloatSO speedSO;
    [SerializeField]
    BoolSO pickUpFood;
    void Start()
    {
        speedSO.value = speed;
    }

    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Foooooooooood");
        if (pickUpFood.state)
        {
            if (collision.gameObject.CompareTag("Food"))
            {
                //Add To inventory
                Destroy(collision.gameObject);
            }
        }
    }
    public void SetPickup()
    {
        pickUpFood.state = true;
    }
}
