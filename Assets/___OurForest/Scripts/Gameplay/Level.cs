using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<SpawnPoint> spawners;

    public List<SpawnPoint> Spawners { get => spawners; set => spawners = value; }

    // Start is called before the first frame update
    void Start()
    {
        spawners = GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
