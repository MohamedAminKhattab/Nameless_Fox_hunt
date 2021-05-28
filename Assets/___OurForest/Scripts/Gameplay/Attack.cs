using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    Transform arrowSpawn;
    [SerializeField]
    float shootForce = 20f;
    [SerializeField]
    BoolSO attack;
    [SerializeField]
    GameManager _GM;
    [SerializeField]
    BoolSO attackAnim;
    [SerializeField]
    BoolSO attackSound;
    bool instantiateArrow;

    public GameManager GM { get => _GM; set => _GM = value; }

    void Start()
    {
        attackSound.state = false;
        instantiateArrow = false;
    }

    void Update()
    {
        if (attack.state)
        {
            attack.state = false;
            StartCoroutine(Attacking());
            if (instantiateArrow)
            {
                instantiateArrow = false;
                if (_GM.Inv.GetItemCount(ItemTypes.Weapon) > 0)
                {
                    attackSound.state = true;
                    Debug.LogWarning($"ArrowAmount {_GM.Inv.GetItemCount(ItemTypes.Weapon)}");
                    _GM.Inv.UseItem(ItemTypes.Weapon, 1);
                    GameObject arrowInst = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
                    Rigidbody rb = arrowInst.GetComponent<Rigidbody>();
                    rb.velocity = player.transform.forward * shootForce;
                }
            }
        }
    
    }

    IEnumerator Attacking()
    {
        // Debug.Log("Attacking");
        attackAnim.state = true;
        //Debug.Log(attackAnim.state);
        var wait = new WaitForSeconds(1.5f);
        yield return wait;
        instantiateArrow = true;
        // attack.state = false;
    }
}
