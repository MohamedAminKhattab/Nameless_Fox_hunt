using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField]
    BoolSO eatingSound;
    [SerializeField]
    BoolSO fetchingSound;
    [SerializeField]
    BoolSO playerDeathSound;
    NavMeshObstacle obstacle;
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
        playerHealth.Death = playerDeath;
        playerHealth.dead = false;
        //_GM.Inv.Capacity = 0;
        obstacle = GetComponent<NavMeshObstacle>();
    }

    void Update()
    {
        if (playerHealth.dead && !playerDeathSound.state)
            playerDeathSound.state = true;
  
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("bullet"))
        {
            playerHealth.ApplyDamage(damagePoints);
            //Debug.Log(playerHealth.currentHealth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Entered");
        if (other.gameObject.CompareTag("bullet"))
        {
            playerHealth.ApplyDamage(damagePoints);
            //Debug.Log(playerHealth.currentHealth);
        }
        if (other.gameObject.CompareTag("Bush"))
        {
            obstacle.enabled = false;
        }


        if (other.gameObject.CompareTag("Vine"))
        {
            resource = "Vine";
            obj = other.gameObject;
            CollectResource();
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            resource = "Rock";
            obj = other.gameObject;
            CollectResource();
            Debug.Log("Rock");
        }
        if (other.gameObject.CompareTag("Food"))
        {
            obj = other.gameObject;
            PickUpFood();
        }

        if (other.gameObject.CompareTag("Wood"))
        {
            obj = other.gameObject;
            CutWood();
        }

        if (other.gameObject.CompareTag("Weapon"))
        {
            obj = other.gameObject;
            PickUpWeapon();
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            obstacle.enabled = true;
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
            pickUpFood.state = false;
            fetchingSound.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Food);
    }
    void CutWood()
    {
            cutWood.state = false;
            FetchAnim.state = true;
            fetchingSound.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Wood);
    }
    void CollectResource()
    {
      
            collectResource.state = false;
            fetchingSound.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            if (resource == "Vine")
                _GM.Inv.AddItem(ItemTypes.Vine);
            else if (resource == "Rock")
                _GM.Inv.AddItem(ItemTypes.Rock);
            resource = "";
    }
    void PickUpWeapon()
    {
            pickUpWeapon.state = false;
            inInput.state = false;
            FetchAnim.state = true;
            StartCoroutine(Fetching());
            //Add to inventory
            _GM.Inv.AddItem(ItemTypes.Weapon);

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
                eatingSound.state = true;
                StartCoroutine(Eating());
                // Debug.Log(playerHealth.currentHealth);
            }
        }
    }
    //IEnumerator CuttingWood()
    //{
    //    var wait = new WaitForSeconds(8.0f);
    //    //Debug.Log("Wait");
    //    yield return wait;
    //    Destroy(obj);
    //}

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