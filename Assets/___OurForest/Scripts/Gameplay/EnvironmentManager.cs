using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameManager GM { get => _GM; set => _GM = value; }
    [SerializeField] List<Tile> tiles = new List<Tile>(1500);
    [SerializeField] List<SpawnPoint> spawnPoints;
    [SerializeField] GameObject currentLevel;
    [SerializeField] EventSO LevelLoadedEvent;
    [SerializeField] GameManager _GM;
    private static EnvironmentManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        spawnPoints = new List<SpawnPoint>();
    }
    public void Load()
    {
        currentLevel = FindObjectOfType<Level>().gameObject;
        tiles = GetComponentsInChildren<Tile>().ToList<Tile>();
        spawnPoints = currentLevel.GetComponent<Level>().Spawners;
        foreach (var sp in spawnPoints)
        {
            sp.GM = _GM;
        }
    }
    public List<Tile> GetResourceTiles()
    {
        var t = tiles.Where<Tile>(a => a.Has_Resource == true).ToList();
        return t;
    }
}
