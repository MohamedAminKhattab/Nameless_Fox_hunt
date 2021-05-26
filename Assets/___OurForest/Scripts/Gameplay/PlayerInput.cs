using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    IInputManager inputManager;
    [SerializeField]
    Vector3SO movement;
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
    [SerializeField]
    BoolSO crouch;  
    [SerializeField]
    BoolSO attack;
    [SerializeField]
    BoolSO inInput;
    void Start()
    {
        

        if (null == inputManager)
        {
            inputManager = new InputHandler();
            // Debug.Log("nulll");
        }
        pickUpFood.state = false;
        collectResource.state = false;
        cutWood.state = false;
        eatFood.state = false;
        crouch.state = false;
        inInput.state = false;
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if (inputManager.GetForword())
        {
            movement.z++;
        }
        if (inputManager.GetBackword())
        {
            movement.z--;
        }
        if (inputManager.GetRight())
        {
            movement.x++;
        }
        if (inputManager.GetLeft())
        {
            movement.x--;
        }
        if (inputManager.PickUpFood())
        {
            pickUpFood.state = true;
            inInput.state = true;
        }
        if (inputManager.CutWood())
        {
            cutWood.state = true;
            inInput.state = true;
        }
        if (inputManager.CollectResource())
        {
            collectResource.state = true;
            inInput.state = true;
        }
        if (inputManager.PickUpWeapon())
        {
            pickUpWeapon.state = true;
            inInput.state = true;
        }
        if (inputManager.EatFood())
        {
            eatFood.state = true;
        }
        if (inputManager.Crouch())
        {
            crouch.state = true;
           // Debug.Log("Crouch");
        }
        if (inputManager.SteelthAttack())
        {
            attack.state =true;
            //Debug.LogWarning("Attacking");
        }
        this.movement.value = movement;
    }
    public void WantToCutWood()
    {
        cutWood.state = true;
        inInput.state = true;
    }
    public void WantToPickUpFood()
    {
        pickUpFood.state = true;
        inInput.state = true;
    }
    public void WantToFetchResource()
    {
        collectResource.state = true;
        inInput.state = true;
    }
    public void WantToPickUpWeapon()
    {
        collectResource.state = true;
        inInput.state = true;
    }

    public void WantToEatFood()
    {
        eatFood.state = true;
    }
    public void WantToCrouch()
    {
        crouch.state = true;
    }
    public void WantToAttack()
    {
        attack.state = true;
       // Debug.LogWarning("Attacking");
    }

}
