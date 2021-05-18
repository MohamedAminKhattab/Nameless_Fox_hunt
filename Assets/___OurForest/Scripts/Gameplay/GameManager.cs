using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Inventory inv;

    public Inventory Inv { get => inv;}
    [SerializeField] Player player;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] int LevelWaveCount = 3;
    [SerializeField] int deadpoints = 0;
    [SerializeField] int currentwave=0;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        inv = new Inventory();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        playerWon.state = false;
        gameOver.state = false;
        currentwave = 1;
    }

    void Update()
    {
        
        
    }
    public void OnPlayerDied()
    {
        playerWon.state = false;
        gameOver.state = true;
    }
    public void onEnemyDied()
    {
        foreach (var sp in spawnPoints)
        {
            if(sp.CurrentTroop==0)
            {
                deadpoints++;
            }
        }
        if(deadpoints==spawnPoints.Count)
        {
            if(currentwave<LevelWaveCount)
            {
                currentwave++;
                foreach (var sp in spawnPoints)
                {
                    sp.LaunchWave();
                }
            }
            playerWon.state = true;
            gameOver.state = true;
        }
    }
}
