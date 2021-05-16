using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField]List<Tile> tiles = new List<Tile>(1500);
    private void Start()
    {
        tiles = GetComponentsInChildren<Tile>().ToList<Tile>();
    }
    public List<Tile> GetResourceTiles()
    {
        var t = tiles.Where<Tile>(a => a.Has_Resource == true).ToList();
            return t;
    }
}
