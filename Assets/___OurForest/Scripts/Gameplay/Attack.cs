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
    float shootForce = 10;
    [SerializeField]
    BoolSO attack;
    [SerializeField]
    GameManager _GM;
    [SerializeField]
    BoolSO attackAnim;
    [SerializeField]
    BoolSO attackSound;
    [SerializeField] TransformSO Enemy;

    bool instantiateArrow;

    public GameManager GM { get => _GM; set => _GM = value; }

    void Start()
    {
        attackSound.state = false;
        instantiateArrow = false;
        Enemy.value = null;
    }

    void Update()
    {
        if (attack.state && Enemy.value)
        {

            attack.state = false;
            if (_GM.Inv.GetItemCount(ItemTypes.Weapon) > 0)
            {
                StartCoroutine(Attacking());
                if (instantiateArrow)
                {
                    instantiateArrow = false;

                    {
                        attackSound.state = true;
                        //Debug.LogWarning($"ArrowAmount {_GM.Inv.GetItemCount(ItemTypes.Weapon)}");
                        _GM.Inv.UseItem(ItemTypes.Weapon, 1);
                        GameObject arrowInst = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
                        Rigidbody rb = arrowInst.GetComponent<Rigidbody>();
                        Vector3 direction = Enemy.value.position - arrowSpawn.position;
                        direction.y = player.transform.position.y;
                        player.transform.forward = direction;
                        rb.velocity = direction* shootForce;
                        //Enemy.value = null;
                    }
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