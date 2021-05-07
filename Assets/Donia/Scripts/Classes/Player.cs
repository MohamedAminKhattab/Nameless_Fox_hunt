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
    void Start()
    {
        cutWood.state = false;
        speedSO.value = speed;
        FetchAnim.state = false;
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
            if (collisionTag == "Resource")
                CollectResource();
            if (collisionTag == "Food")
                PickUpFood();
            if (collisionTag == "Wood")
                CutWood();
            if (collisionTag == "Weapon")
                Craft();
        }
    }
     void PickUpFood()
    {
      if(pickUpFood.state)
        {
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
        }
    } 
     void CutWood()
    {
        if(cutWood.state)
        {
            CutAnim.state = true;
            StartCoroutine(CuttingWood());
            //Add to inventory

        }
    }
    void CollectResource()
    {
        if (collectResource.state)
        {
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory

        }
    }
    void Craft()
    {
        if(pickUpWeapon.state)
        {
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory

        }
    }
    IEnumerator CuttingWood()
    {
        var wait = new WaitForSeconds(8.0f);
        //Debug.Log("Wait");
        yield return wait;
        Destroy(obj);
    } 
   
    IEnumerator Fetching()
    {
        var wait = new WaitForSeconds(5.0f);
        //Debug.Log("Wait");
        yield return wait;
        Destroy(layerHit);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collison,0.2f);
     }
}
