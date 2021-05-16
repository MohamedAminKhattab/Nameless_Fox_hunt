using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField]List<Tile> tiles = new List<Tile>(1500);
    [SerializeField] GameObject [] LevelPrefabs= new GameObject[10];
    [SerializeField] string levelNumber;
    [SerializeField] GameObject currentLevel;
    [SerializeField] GameManager _GM;

    public string LevelNumber { get => levelNumber; set => levelNumber = value; }

    private void Start()
    {
        Load(LevelNumber);
    }
    private void Update()
    {
    }
    private void Load(string Number)
    {
        int.TryParse(Number, out int number);
        currentLevel = Instantiate(LevelPrefabs[number], transform);
        tiles = GetComponentsInChildren<Tile>().ToList<Tile>();
    }
    public List<Tile> GetResourceTiles()
    {
        var t = tiles.Where<Tile>(a => a.Has_Resource == true).ToList();
            return t;
    }
}
