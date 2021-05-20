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
    [SerializeField] CameraFollow cfollow;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] GameObject foxPrefab;
    [SerializeField] GameObject fox;
    [SerializeField] GameObject playerPrefab;
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
        _EM = FindObjectOfType<EnvironmentManager>();
        playerWon.state = false;
        gameOver.state = false;
    }
    void Update()
    {


    }
    public void StartLevel()
    {
        player = Instantiate(playerPrefab,transform.position,Quaternion.identity).GetComponent<Player>();
        player.GM = this;
        fox=Instantiate(foxPrefab, transform.position, Quaternion.identity);
        fox.GetComponent<FoxBehaviours>().Player = player.transform;
        spawnPoints = _EM.GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
        cfollow.Target = player.transform;
        currentwave = 1;
        foreach (var sp in spawnPoints)
        {
            sp.GM = this;
            sp.Fox = fox.transform;
            sp.Yelena = player.transform;
        }
    }
    public void SpawnEnemies()
    {
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
    public void OnEnemyDied()
    {
        spawnPoints = _EM.GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
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