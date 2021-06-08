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
    public CameraFollow Cfollow { get => cfollow; set => cfollow = value; }

    [SerializeField] Player player;
    [SerializeField] CameraFollow cfollow;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] BoolSO playerWon;
    [SerializeField] BoolSO gameOver;
    [SerializeField] BoolSO togamePlay;
    [SerializeField] BoolSO timerisRunning;
    [SerializeField] FloatSO RemainingTime;
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
    [SerializeField] PlayerSaveSO save;
    [SerializeField] int selectedLevel;
    [SerializeField] HealthSO foxhealth;
    [SerializeField] HealthSO playerhealth;
    private static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            inv = new Inventory();
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
            inv.AddItem(ItemTypes.Weapon);
            inv.AddItem(ItemTypes.Weapon);
            inv.AddItem(ItemTypes.Weapon);
            inv.AddItem(ItemTypes.Weapon);
            inv.AddItem(ItemTypes.Weapon);

            inv.AddItem(ItemTypes.Food);
            inv.AddItem(ItemTypes.Food);
            inv.AddItem(ItemTypes.Food);
            inv.AddItem(ItemTypes.Food);
            inv.AddItem(ItemTypes.Food);
            save.Save(100, 100, Inv.Itemlist, false);
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
    public void Removeoldinstance()
    {
        FoxBehaviours f = GetComponentInChildren<FoxBehaviours>();
        Player p = GetComponentInChildren<Player>();
        if (p != null && f != null)
        {
            //Debug.LogWarning("Found them");
            Destroy(p.gameObject);
            Destroy(f.gameObject);
           // Debug.LogWarning("deleted them");
        }
    }
    public void StartLevel()
    {
        Removeoldinstance();
        _EM = FindObjectOfType<EnvironmentManager>();
        _EM.GM = this;
        cfollow = FindObjectOfType<CameraFollow>();
        playerWon.state = false;
        gameOver.state = false;
        togamePlay.state = true;
        _UM.SetUI();
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform).GetComponent<Player>();
        player.GM = this;
        player.GetComponentInChildren<Attack>().GM = this;
        fox = Instantiate(foxPrefab, transform.position, Quaternion.identity, transform);
        fox.GetComponent<FoxBehaviours>().Player = player.transform;
        fox.GetComponent<FoxInventory>().Gm = this;
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        cfollow.Target = player.transform;
        currentwave = 1;
        currentTroopCount = 0;
        save.Load(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, selectedLevel);
        foreach (var sp in spawnPoints)
        {
            sp.GM = this;
            sp.Fox = fox.transform;
            sp.Yelena = player.transform;
        }
        changecountenemy.Raise();
        StartCoroutine(WaitForWave());
    }
    public void Restart()
    {
        //Debug.Log("Restarting");
        save.Load(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, selectedLevel);
        inv.OnInvItemsChangeHandler?.Invoke(this, EventArgs.Empty);
       // Debug.Log("Restarted");
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
        save.Save(100, 100, Inv.Itemlist, false);
        onPlayerLost.Raise();
    }
    public void OnEnemyDied()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        if (currentTroopCount < 1 && currentwave < LevelWaveCount)
        {
            StartCoroutine(WaitForWave());
            currentwave++;
        }
        else if (currentTroopCount == 0 && currentwave == LevelWaveCount)
        {
            playerWon.state = true;
            gameOver.state = false;
            save.Save(100, 100, Inv.Itemlist, true);
            onPlayerWon.Raise();
        }
    }
    IEnumerator WaitForWave()
    {
        //Debug.LogWarning("All enemies died making new ones");
        timerisRunning.state = true;
        RemainingTime.value = spawnrate * 60;
        yield return new WaitForSeconds(spawnrate * 60);
        SpawnEnemies();
       // Debug.LogWarning("new ones");
    }
}