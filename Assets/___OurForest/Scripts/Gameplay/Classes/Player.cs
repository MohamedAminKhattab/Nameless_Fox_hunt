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
    BoolSO collectResource;
    [SerializeField]
    BoolSO cutWood;
    [SerializeField]
    BoolSO pickUpWeapon;
    [SerializeField]
    BoolSO eatFood;
    GameObject obj;
    GameObject layerHit;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    float hitDistance;
    string collisionTag;
    Vector3 collison;
    [SerializeField]
    BoolSO FetchAnim;
    [SerializeField]
    BoolSO CutAnim; 
    [SerializeField]
    BoolSO EatAnim;
    [SerializeField]
    GameManager _GM;
    string resource = "";
    bool canEatFood;
    void Start()
    {
        cutWood.state = false;
        speedSO.value = speed;
        FetchAnim.state = false;
        EatAnim.state = false;
        canEatFood = false;
        //_GM.Inv.Capacity = 0;
    }

    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, hitDistance))
        {
            layerHit = hit.transform.gameObject;
            collison = hit.point;
            collisionTag = layerHit.tag;
            if (collisionTag == "Vine")
            {
                CollectResource();
                resource = "Vine";
            }
            if (collisionTag == "Rock")
            {
                CollectResource();
                resource = "Rock";
            }
            if (collisionTag == "Food")
                PickUpFood();
            if (collisionTag == "Wood")
                CutWood();
            if (collisionTag == "Weapon")
                PickUpWeapon();
        }
    }
     void FixedUpdate()
    {
        if (eatFood.state)
        {
            CanEat();
             
        }
        Debug.Log(_GM.Inv.GetItemCount(ItemTypes.Food));
    }
    void PickUpFood()
    {
      if(pickUpFood.state)
        {
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Food);
            //Debug.Log("Food");
        }
    } 
     void CutWood()
    {
        if(cutWood.state)
        {
            CutAnim.state = true;
            StartCoroutine(CuttingWood());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Wood);
        }
    }
    void CollectResource()
    {
        if (collectResource.state)
        {
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            if(resource=="Vine")
                _GM.Inv.AddItem(ItemTypes.Vine);
            else if(resource=="Rock")
                _GM.Inv.AddItem(ItemTypes.Rock);
            resource = "";
        }
    }
    void PickUpWeapon()
    {
        if(pickUpWeapon.state)
        {
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Weapon);

        }
    }
    void CanEat()
    {
        canEatFood = _GM.Inv.UseItem(ItemTypes.Food, 1);
        if (canEatFood)
        {
            EatAnim.state = true;
            StartCoroutine(Eating());
        }
    }
    IEnumerator CuttingWood()
    {
        var wait = new WaitForSeconds(8.0f);
        //Debug.Log("Wait");
        yield return wait;
        Destroy(layerHit);
    } 
   
    IEnumerator Fetching()
    {
        var wait = new WaitForSeconds(5.0f);
        //Debug.Log("Wait");
        yield return wait;
        Destroy(layerHit);
    }
    IEnumerator Eating()
    {
        var wait = new WaitForSeconds(3.0f);
        yield return wait;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collison,0.2f);
     }
}