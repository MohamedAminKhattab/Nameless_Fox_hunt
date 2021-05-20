using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Keyboard")]
public class InputHandler : IInputManager
{
    [SerializeField]
    KeyCode backWordCode;
    [SerializeField]
    KeyCode forwordWordCode;
    [SerializeField]
    KeyCode rightCode;
    [SerializeField]
    KeyCode leftCode;
    [SerializeField]
    KeyCode pickupFoodCode;
    [SerializeField]
    KeyCode cutWoodCode;
    [SerializeField]
    KeyCode collectResource;
    [SerializeField]
    KeyCode pickUpWeapon;
    [SerializeField]
    KeyCode eatFood; 
    [SerializeField]
    KeyCode crouch;
    [SerializeField]
    KeyCode attack;

    public override bool CutWood()
    {
        return Input.GetKey(cutWoodCode);

    }

    public override bool GetBackword()
    {
        // Debug.Log("backword");
        return Input.GetKey(backWordCode);
    }

    public override bool GetForword()
    {
        return Input.GetKey(forwordWordCode);
    }

    public override bool GetLeft()
    {
        return Input.GetKey(leftCode);
    }

    public override bool GetRight()
    {
        return Input.GetKey(rightCode);
    }

    public override bool PickUpFood()
    {
        return Input.GetKey(pickupFoodCode);
    }
    public override bool CollectResource()
    {
        return Input.GetKey(collectResource);
    }

    public override bool PickUpWeapon()
    {
        return Input.GetKey(pickUpWeapon);
    }
    public override bool EatFood()
    {
        return Input.GetKey(eatFood);
    }
    public override bool Crouch()
    {
        return Input.GetKey(crouch);
    }  
    public override bool SteelthAttack()
    {
        return Input.GetKey(attack);
    }
}
