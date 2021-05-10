using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    Weapon weapon;
    [SerializeField]
    BoolSO pickUpWeapon;
    float timerCount = 0.1f;

    void Start()
    {
        weapon = new Weapon();
        pickUpWeapon.state = false;
    }
    void Update()
    {
        timerCount -= Time.deltaTime;
        if (timerCount <= 0)
        {
            pickUpWeapon.state = false;
            timerCount = 0.1f;
        }
    }
}
