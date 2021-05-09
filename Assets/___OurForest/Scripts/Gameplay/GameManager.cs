using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory inv;

    public Inventory Inv { get => inv;}
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        inv = new Inventory();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
