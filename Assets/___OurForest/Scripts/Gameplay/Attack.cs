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
    [SerializeField] BoolSO HasTarget;
    [SerializeField]
    GameObject bow;
    bool instantiateArrow;
    [SerializeField] Transform myEnemy;
    int i = 0;
    public GameManager GM { get => _GM; set => _GM = value; }

    void Start()
    {
        attackSound.state = false;
        instantiateArrow = false;
        Enemy.value = myEnemy;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {




            instantiateArrow = false;
            attackAnim.state = true;



            GameObject arrowInst = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
            Rigidbody rb = arrowInst.GetComponent<Rigidbody>();
            Vector3 direction = Enemy.value.position - arrowSpawn.position;
            direction.y = player.transform.position.y;
            player.transform.forward = direction;
            rb.velocity = direction * shootForce;
            // Enemy.value = null;
            HasTarget.state = false;




        }

    }


}