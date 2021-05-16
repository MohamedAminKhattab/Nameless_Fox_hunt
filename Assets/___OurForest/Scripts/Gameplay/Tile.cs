using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Tile:MonoBehaviour
{
    [SerializeField]private Vector3 location;
    [SerializeField] private bool has_resource=false;
    [SerializeField] private bool can_Trap = false;
    [SerializeField] private bool can_Hide=false;
    [SerializeField] private GameObject resourceItem;
    [SerializeField] private Bush bush;
    public Vector3 Location { get =>location; set =>location=value; }
    public bool Has_Resource { get => has_resource; set => has_resource = value; }
    public bool Can_Trap { get => can_Trap; set => can_Trap = value; }
    public GameObject ResourceItem { get => resourceItem; set => resourceItem = value; }
    public bool Can_Hide { get => can_Hide; set => can_Hide = value; }
    public Bush Bush { get => bush; set => bush = value; }
    private void Start()
    {
        Location = transform.position;
        if(resourceItem!=null)
        {
            has_resource = true;
            can_Trap = true;
            can_Hide = false;
        }
        if(TryGetComponent<Bush>(out bush))
        {
            can_Hide = true;
            has_resource = false;
            can_Trap = false;
        }
        if(!TryGetComponent<Bush>(out bush)&&! resourceItem)
        {
            can_Hide = false;
            has_resource = false;
            can_Trap = true;
        }
    }
}
