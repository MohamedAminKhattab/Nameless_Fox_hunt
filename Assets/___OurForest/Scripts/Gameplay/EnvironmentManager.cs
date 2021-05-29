using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] List<Tile> tiles = new List<Tile>(1500);
    [SerializeField] List<SpawnPoint> spawnPoints;
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
        currentLevel = FindObjectOfType<Level>().gameObject;
        tiles = GetComponentsInChildren<Tile>().ToList<Tile>();
        spawnPoints = currentLevel.GetComponent<Level>().Spawners;
        foreach (var sp in spawnPoints)
        {
            sp.GM = _GM;
        }
        surface.BuildNavMesh();
       // LevelLoadedEvent.Raise();
    }
    public List<Tile> GetResourceTiles()
    {
        var t = tiles.Where<Tile>(a => a.Has_Resource == true).ToList();
            return t;
    }
}
