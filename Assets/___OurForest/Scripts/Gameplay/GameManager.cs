using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    Inventory inv = new Inventory();

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
    [SerializeField] BoolSO needtrap;
    [SerializeField] BoolSO hastarget;
    [SerializeField] BoolSO hasenemytarget;
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
    [SerializeField] EventSO enemiesspawned;
    [SerializeField] PlayerSaveSO save;
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] HealthSO foxhealth;
    [SerializeField] HealthSO playerhealth;
    [SerializeField] Slider playerhealthslider;
    [SerializeField] Slider foxhealthslider;

    private static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
            //save.Save(100, 100, Inv.Itemlist, false);
            save.Load(playerhealth.currentHealth, foxhealth.currentHealth, inv.Itemlist, selectedLevel.value);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _UM.SetUIByState();
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
    public void ClearSave()
    {
        inv.ClearInventory();
        save.Clear();
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
        save.Save(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, false);
    }
    public void StartTutorialLevel()
    {
        Removeoldinstance();
        _EM = FindObjectOfType<EnvironmentManager>();
        _EM.GM = this;
        playerWon.state = false;
        gameOver.state = false;
        needtrap.state = false;
        hastarget.state = false;
        hasenemytarget.state = false;
        togamePlay.state = true;
        _UM.SetUIByState();
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform).GetComponent<Player>();
        player.GM = this;
        player.GetComponentInChildren<Attack>().GM = this;
        cfollow = FindObjectOfType<CameraFollow>();
        fox = Instantiate(foxPrefab, transform.position, Quaternion.identity, transform);
        fox.GetComponent<FoxBehaviours>().Player = player.transform;
        fox.GetComponent<FoxInventory>().Gm = this;
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        cfollow.Target = player.transform;
        player.GetComponent<HealthIndicator>().healthBar = playerhealthslider;
        fox.GetComponent<HealthIndicator>().healthBar = foxhealthslider;
        currentwave = 1;
        currentTroopCount = 0;
        save.Save(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, false);
        foreach (var sp in spawnPoints)
        {
            sp.GM = this;
            sp.Fox = fox.transform;
            sp.Yelena = player.transform;
        }
        changecountenemy.Raise();
        StopAllCoroutines();
    }
    public void StartTutorialWave()
    {
        StartCoroutine(WaitForWave());
    }
    public void StartLevel()
    {
        Removeoldinstance();
        _EM = FindObjectOfType<EnvironmentManager>();
        _EM.GM = this;
        playerWon.state = false;
        gameOver.state = false;
        needtrap.state = false;
        hastarget.state = false;
        hasenemytarget.state = false;
        togamePlay.state = true;
        _UM.SetUIByState();
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform).GetComponent<Player>();
        player.GM = this;
        player.GetComponentInChildren<Attack>().GM = this;
        cfollow = FindObjectOfType<CameraFollow>();
        fox = Instantiate(foxPrefab, transform.position, Quaternion.identity, transform);
        fox.GetComponent<FoxBehaviours>().Player = player.transform;
        fox.GetComponent<FoxInventory>().Gm = this;
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        cfollow.Target = player.transform;
        player.GetComponent<HealthIndicator>().healthBar = playerhealthslider;
        fox.GetComponent<HealthIndicator>().healthBar = foxhealthslider;
        currentwave = 1;
        currentTroopCount = 0;
        save.Save(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, false);
        foreach (var sp in spawnPoints)
        {
            sp.GM = this;
            sp.Fox = fox.transform;
            sp.Yelena = player.transform;
        }
        changecountenemy.Raise();
        StopAllCoroutines();
        StartCoroutine(WaitForWave());
    }
    public void Restart()
    {
        // Debug.Log("Restarting");
        changecountenemy.Raise();
        save.Load(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, selectedLevel.value);
        inv.OnInvItemsChangeHandler?.Invoke(this, EventArgs.Empty);
        // Debug.Log("Restarted");
    }
    public void RestartTut()
    {
        // Debug.Log("Restarting");
        changecountenemy.Raise();
        save.Load(playerhealth.currentHealth, foxhealth.currentHealth, Inv.Itemlist, selectedLevel.value);
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
    public void FoxHeal()
    {
        if (Inv.GetItemCount(ItemTypes.Food) > 0)
        {
            //Debug.Log($"Fox" + foxhealth.currentHealth);
            if (foxhealth.currentHealth < foxhealth.initialHealth)
            {
              //  Debug.Log($"Fox" + foxhealth.currentHealth);
                Inv.UseItem(ItemTypes.Food, 1);
                foxhealth.Healing(10);
            }
        }
    }
    public void OnPlayerDied()
    {
        playerWon.state = false;
        gameOver.state = true;
        //save.Save(100, 100, Inv.Itemlist, false);
        StartCoroutine(WaitforDead());
        onPlayerLost.Raise();
    }
    public void OnEnemyDied()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>().ToList<SpawnPoint>();
        if (currentTroopCount < 1 && currentwave < LevelWaveCount)
        {
            StopAllCoroutines();
            StartCoroutine(WaitForWave());
            currentwave++;
        }
        else if (currentTroopCount == 0 && currentwave == LevelWaveCount)
        {
            playerWon.state = true;
            gameOver.state = false;
            if (selectedLevel.value >= save.LastClearedLevel)
            {
                save.Save(100, 100, Inv.Itemlist, true);
            }
            else
            {
                Debug.Log("Shit here");
                save.Save(100, 100, Inv.Itemlist, false);
            }
            onPlayerWon.Raise();
        }
    }
    IEnumerator WaitForWave()
    {
        // Debug.LogWarning("All enemies died making new ones");
        timerisRunning.state = true;
        RemainingTime.value = spawnrate * 60;
        yield return new WaitForSeconds(spawnrate * 60);
        SpawnEnemies();
        enemiesspawned.Raise();
        // Debug.LogWarning("new ones");
    }
    IEnumerator WaitforDead()
    {
        yield return new WaitForSeconds(3.0f);
    }
}