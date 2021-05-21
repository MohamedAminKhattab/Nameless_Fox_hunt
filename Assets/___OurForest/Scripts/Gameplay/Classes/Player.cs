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
    Vector3 collison;
    [SerializeField]
    BoolSO FetchAnim;
    [SerializeField]
    BoolSO CutAnim;
    [SerializeField]
    BoolSO EatAnim;
    [SerializeField]
    BoolSO HideAnim;
    [SerializeField]
    GameManager _GM;
    [SerializeField]
    HealthSO playerHealth;
    [SerializeField]
    float initialHealth = 100;
    [SerializeField]
    float healingPoints = 15;
    [SerializeField]
    float damagePoints = 5;
    [SerializeField]
    EventSO playerDeath;
    string resource = "";
    bool canEatFood;
    [SerializeField]
    BoolSO inInput;
    public GameManager GM { get => _GM; set => _GM = value; }

    void Start()
    {
        cutWood.state = false;
        speedSO.value = speed;
        FetchAnim.state = false;
        EatAnim.state = false;
        canEatFood = false;
        HideAnim.state = false;
        playerHealth.initialHealth = initialHealth;
        
        //_GM.Inv.Capacity = 0;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Entered");
        if (other.gameObject.tag == "Bush")
            HideAnim.state = true;
        if (other.gameObject.tag == "Bullet")
        {
            playerHealth.ApplyDamage(damagePoints, playerDeath);
            //Debug.Log(playerHealth.currentHealth);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (inInput.state)
        {
            if (collision.gameObject.tag == "Vine")
            {
                CollectResource();
                resource = "Vine";
            }
            if (collision.gameObject.tag == "Rock")
            {
                CollectResource();
                resource = "Rock";
            }
            if (collision.gameObject.tag == "Food")
                PickUpFood();

            if (collision.gameObject.tag == "Wood")
                CutWood();

            if (collision.gameObject.tag == "Weapon")
                PickUpWeapon();

            obj = collision.gameObject;
        }
    }
    void FixedUpdate()
    {
        if (eatFood.state)
        {
            CanEat();
            eatFood.state = false;
            //Debug.Log(_GM.Inv.GetItemCount(ItemTypes.Food));
        }

    }
    void PickUpFood()
    {
        if (pickUpFood.state)
        {
            pickUpFood.state = false;
            inInput.state = false;
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Food);
            //Debug.Log("pick up Food");
        }
    }
    void CutWood()
    {
        if (cutWood.state)
        {
            cutWood.state = false;
            inInput.state = false;
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
            collectResource.state = false;
            inInput.state = false;
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            if (resource == "Vine")
                _GM.Inv.AddItem(ItemTypes.Vine);
            else if (resource == "Rock")
                _GM.Inv.AddItem(ItemTypes.Rock);
            resource = "";
        }
    }
    void PickUpWeapon()
    {
        if (pickUpWeapon.state)
        {
            pickUpWeapon.state = false;
            inInput.state = false;
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Weapon);

        }
    }
    void CanEat()
    {
        canEatFood = _GM.Inv.GetItemCount(ItemTypes.Food) > 0;
       // Debug.Log(playerHealth.currentHealth);
        if (canEatFood)
        {
            if (playerHealth.currentHealth < playerHealth.initialHealth)
            {
                _GM.Inv.UseItem(ItemTypes.Food, 1);
                playerHealth.Healing(healingPoints);
                EatAnim.state = true;
                StartCoroutine(Eating());
               // Debug.Log(playerHealth.currentHealth);
            }
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
        Destroy(obj);
       // Debug.Log(obj.tag);
        
    }
    IEnumerator Eating()
    {
        var wait = new WaitForSeconds(3.0f);
        yield return wait;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collison, 0.2f);
    }

}