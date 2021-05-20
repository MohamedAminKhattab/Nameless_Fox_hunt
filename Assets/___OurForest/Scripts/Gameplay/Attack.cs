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
    float shootForce=20f;
    [SerializeField]
    BoolSO attack;
    [SerializeField]
    GameManager _GM;
    [SerializeField]
    BoolSO attackAnim;
    void Start()
    {
        
    }

    void Update()
    {
        if (attack.state)
        {
            if (_GM.Inv.GetItemCount(ItemTypes.Weapon) > 0)
            {
                StartCoroutine(Attacking());
            }
        }
    }
    IEnumerator Attacking()
    {
        attackAnim.state = true;
        var wait = new WaitForSeconds(1f);
        yield return wait;
        _GM.Inv.UseItem(ItemTypes.Weapon,1);
        GameObject arrowInst = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
        Rigidbody rb = arrowInst.GetComponent<Rigidbody>();
        rb.velocity = player.transform.forward * shootForce;
        attack.state = false;
    }
}
