using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform fox;
    [SerializeField] Transform yelena;
    [SerializeField] Transform defaultgoal;
    [SerializeField] int spawnCount = 1;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int currentTroop;
    [SerializeField] List<GameObject> troops;

    public int CurrentTroop { get => currentTroop; set => currentTroop = value; }
    public List<GameObject> Troops { get => troops;}

    void Start()
    {
        fox = GameObject.FindGameObjectWithTag("Fox").transform;
        yelena = GameObject.FindGameObjectWithTag("Player").transform;
        defaultgoal = GameObject.FindGameObjectWithTag("Start").transform;
        troops = new List<GameObject>();
        CurrentTroop = 0;
    }
    public void LaunchWave()
    {
        if (CurrentTroop==0)
        {
            for (int i = 0; i < spawnCount; i++)
            {
            Troops.Add(SpawnEnemy());
            }
        }
    }
    public GameObject SpawnEnemy()
    {
        GameObject Troop= Instantiate(enemyPrefab, this.transform.position, Quaternion.identity, this.transform);
        Troop.GetComponent<EnemyBehaviours>().Fox = fox;
        Troop.GetComponent<EnemyBehaviours>().Yelena = yelena;
        Troop.GetComponent<EnemyBehaviours>().DefaultGoal1 = defaultgoal;
        CurrentTroop++;
        return Troop;
    }
    public void Enemydied()
    {
        CurrentTroop--;
    }
}
