using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySO : ScriptableObject
{
    public int Capacity;
    int maxCapacity;
    public List<Item> itemlist;
}
