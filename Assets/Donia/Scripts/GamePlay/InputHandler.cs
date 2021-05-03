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
}
