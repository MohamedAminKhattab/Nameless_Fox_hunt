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
    [SerializeField] Player player;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    int LevelWaveCount = 3;
    int currentwave;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        inv = new Inventory();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        currentwave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void onEnemyDied()
    {
        foreach (var sp in spawnPoints)
        {
            //if(sp.CurrentTroop==0&&)
        }
    }
}
