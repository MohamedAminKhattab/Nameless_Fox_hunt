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
    [SerializeField]
    BoolSO cutWood;
    GameObject obj;
    
    void Start()
    {
        cutWood.state = false;
        speedSO.value = speed;
    }

    void Update()
    {
      
    }
    private void OnCollisionStay(Collision collision)
    {
        if (pickUpFood.state)
        {
            if (collision.gameObject.CompareTag("Food"))
            {
                //Add To inventory
                obj = collision.gameObject;
                StartCoroutine(PickUpFood());
            }
        }  
        if (cutWood.state)
        {
            if (collision.gameObject.CompareTag("Wood"))
            {
                //Add To inventory
                //  Debug.Log("cutting");
                obj = collision.gameObject;
                StartCoroutine(CuttingWood());
                
            }
        }
    }
    public void SetPickup()
    {
        pickUpFood.state = true;
    } 
    public void SetCutWood()
    {
        cutWood.state = true;
    }
    IEnumerator CuttingWood()
    {
        var wait = new WaitForSeconds(5.0f);
        //Debug.Log("Wait");
        yield return wait;
        Destroy(obj);
    } 
    IEnumerator PickUpFood()
    {
        var wait = new WaitForSeconds(2.0f);
        //Debug.Log("Wait");
        yield return wait;
        Destroy(obj);
    }
}
