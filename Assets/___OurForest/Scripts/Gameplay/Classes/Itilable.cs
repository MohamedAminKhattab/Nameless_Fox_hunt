using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Itilable : MonoBehaviour
{
    private Vector3 location;
    private bool walkable;
    private bool has_resource;
    private bool can_Trap;
    private GameObject resourceItem;
    public Vector3 Location { get =>location; set =>location=value; }
    public bool Walkable { get => walkable; set => walkable = value; }
    public bool Has_Resource { get => has_resource; set => has_resource = value; }
    public bool Can_Trap { get => can_Trap; set => can_Trap = value; }
    public GameObject ResourceItem { get => resourceItem; set => resourceItem = value; }
   
}
