using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    IInputManager inputManager;
    [SerializeField]
    Vector3SO movement;
    [SerializeField]
    BoolSO pickUpFood;
    void Start()
    {

        if (null == inputManager)
        {
            inputManager = new InputHandler();
            // Debug.Log("nulll");
        }
        pickUpFood.state = false;
    }

    void Update()
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

        }
        if (inputManager.CutWood())
        {
            //Do something

        }
        this.movement.value = movement;
    }


}
