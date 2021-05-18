using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Inventory inv;

    public Inventory Inv { get => inv; }
    public int CurrentTroopCount { get => currentTroopCount; set => currentTroopCount = value; }
    public List<SpawnPoint> SpawnPoints { get => spawnPoints;}

    [SerializeField] Player player;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] EnvironmentManager _EM;
    [SerializeField] int LevelWaveCount = 3;
    [SerializeField] int currentwave = 0;
    [SerializeField] int currentTroopCount = 0;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        inv = new Inventory();
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
        _EM = FindObjectOfType<EnvironmentManager>();
        playerWon.state = false;
        gameOver.state = false;

    }
    void Update()
    {


    }
    public void StartLevel()
    {
        spawnPoints = _EM.GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
        currentwave = 1;
        foreach (var sp in spawnPoints)
        {
            sp.LaunchWave();
        }
    }
    public void OnPlayerDied()
    {
        playerWon.state = false;
        gameOver.state = true;
    }
    public void onEnemyDied()
    {
        if (currentTroopCount == 0 && currentwave < LevelWaveCount)
        {
            foreach (var sp in spawnPoints)
            {
                sp.LaunchWave();
            }
            currentwave++;
        }
        else if (currentTroopCount == 0 && currentwave == LevelWaveCount)
        {
            playerWon.state = true;
            gameOver.state = true;
        }
    }
}