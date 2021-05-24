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

    public GameManager GM { get => _GM; set => _GM = value; }

    void Start()
    {
    }

    void Update()
    {
        if (attack.state==true)
        {
            if (_GM.Inv.GetItemCount(ItemTypes.Weapon) > 0)
            {
                Debug.LogWarning($"ArrowAmount{_GM.Inv.GetItemCount(ItemTypes.Weapon)}");
                StartCoroutine(Attacking());
            }
        }
    }
    IEnumerator Attacking()
    {
       // Debug.Log("Attacking");
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
