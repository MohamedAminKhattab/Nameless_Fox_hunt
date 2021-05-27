using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles = new List<Tile>(1500);
    [SerializeField] GameObject[] LevelPrefabs = new GameObject[10];
    [SerializeField] List<SpawnPoint> spawnPoints;
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] GameObject currentLevel;
    [SerializeField] EventSO LevelLoadedEvent;
    [SerializeField] GameManager _GM;
    [SerializeField] NavMeshSurface surface;

    public GameManager GM { get => _GM; set => _GM = value; }

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        spawnPoints = new List<SpawnPoint>();
        Load();
    }
    private void Load()
    {
        currentLevel = Instantiate(LevelPrefabs[selectedLevel.value], transform);
        tiles = GetComponentsInChildren<Tile>().ToList<Tile>();
        spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
        foreach (var sp in spawnPoints)
        {
            sp.GM = _GM;
        }
        surface.BuildNavMesh();
        LevelLoadedEvent.Raise();
    }
    public List<Tile> GetResourceTiles()
    {
        var t = tiles.Where<Tile>(a => a.Has_Resource == true).ToList();
            return t;
    }
}
