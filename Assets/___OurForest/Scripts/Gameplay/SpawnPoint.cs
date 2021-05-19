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
    [SerializeField] GameManager _GM;
    [SerializeField] EventSO enemyCountChange;

    public int CurrentTroop { get => currentTroop; set => currentTroop = value; }
    public List<GameObject> Troops { get => troops;}
    public EventSO EnemyCountChange { get => enemyCountChange;}
    public Transform Fox { get => fox; set => fox = value; }
    public Transform Yelena { get => yelena; set => yelena = value; }
    public Transform Defaultgoal { get => defaultgoal; set => defaultgoal = value; }
    public GameManager GM { get => _GM; set => _GM = value; }

    void Start()
    {
        _GM = FindObjectOfType<GameManager>();
        troops = new List<GameObject>();
        CurrentTroop = 0;
    }
    public void LaunchWave()
    {
        if (CurrentTroop==0)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                //Troops.Add(SpawnEnemy());
                SpawnEnemy();
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
        _GM.CurrentTroopCount++;
        enemyCountChange.Raise();
        return Troop;
    }
    public void Enemydied()
    {
        CurrentTroop--;
        _GM.CurrentTroopCount++;
        enemyCountChange.Raise();
    }
}
