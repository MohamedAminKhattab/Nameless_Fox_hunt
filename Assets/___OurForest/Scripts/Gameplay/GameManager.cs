using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory inv;

    public Inventory Inv { get => inv;}
    List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    int LevelWaveCount = 3;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        inv = new Inventory();
        spawnPoints = GetComponents<SpawnPoint>().ToList<SpawnPoint>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
