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
    public List<SpawnPoint> SpawnPoints { get => spawnPoints; }

    [SerializeField] Player player;
    [SerializeField] CameraFollow cfollow;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] BoolSO togamePlay;
    [SerializeField] GameObject foxPrefab;
    [SerializeField] GameObject fox;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] EnvironmentManager _EM;
    [SerializeField] float spawnrate;
    [SerializeField] UIManager _UM;
    [SerializeField] int LevelWaveCount = 3;
    [SerializeField] int currentwave = 0;
    [SerializeField] int currentTroopCount = 0;
    [SerializeField] EventSO onPlayerWon;
    [SerializeField] EventSO onPlayerLost;
    [SerializeField] EventSO changecountenemy;
    private static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            inv = new Inventory();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _UM.SetUI();
    }
    public void StartLevel()
    {
        _EM = FindObjectOfType<EnvironmentManager>();
        _EM.GM = this;
        cfollow = FindObjectOfType<CameraFollow>();
        playerWon.state = false;
        gameOver.state = false;
        togamePlay.state = true;
        _UM.SetUI();
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity).GetComponent<Player>();
        player.GM = this;
        fox = Instantiate(foxPrefab, transform.position, Quaternion.identity);
        fox.GetComponent<FoxBehaviours>().Player = player.transform;
        fox.GetComponent<FoxInventory>().Gm = this;
        spawnPoints = _EM.GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
        cfollow.Target = player.transform;
        currentwave = 1;
        currentTroopCount = 0;
        inv.AddItem(ItemTypes.Trap);
        inv.AddItem(ItemTypes.Trap);
        inv.AddItem(ItemTypes.Trap);
        inv.AddItem(ItemTypes.Trap);
        inv.AddItem(ItemTypes.Trap);
        inv.AddItem(ItemTypes.Weapon);
        inv.AddItem(ItemTypes.Weapon);
        inv.AddItem(ItemTypes.Weapon);
        inv.AddItem(ItemTypes.Weapon);
        inv.AddItem(ItemTypes.Weapon);
        foreach (var sp in spawnPoints)
        {
            sp.GM = this;
            sp.Fox = fox.transform;
            sp.Yelena = player.transform;
        }
        Debug.LogWarning("instart");
        StartCoroutine(WaitForWave());
    }
    public void SpawnEnemies()
    {
        foreach (var sp in spawnPoints)
        {
            sp.LaunchWave();
        }
        changecountenemy.Raise();
    }
    public void OnPlayerDied()
    {
        playerWon.state = false;
        gameOver.state = true;
        onPlayerLost.Raise();
    }
    public void OnEnemyDied()
    {
        Debug.LogWarning("inenemydied");
        spawnPoints = _EM.GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
        if (currentTroopCount < 1 && currentwave < LevelWaveCount)
        {
            Debug.LogWarning("All enemies died making new ones");
            StartCoroutine(WaitForWave());
            currentwave++;
        }
        else if (currentTroopCount == 0 && currentwave == LevelWaveCount)
        {
            playerWon.state = true;
            gameOver.state = false;
            onPlayerWon.Raise();
        }
    }
    IEnumerator WaitForWave()
    {
        yield return new WaitForSeconds(spawnrate * 60);
        SpawnEnemies();
    }
}