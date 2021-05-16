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
    [SerializeField] EventSO onEnemyDieEvent;
    // Start is called before the first frame update
    void Start()
    {
        currentTroop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTroop<spawnCount)
        {
            for (int i = 0; i < spawnCount; i++)
            {
            SpawnEnemy();
            }
        }
    }
    public void SpawnEnemy()
    {
        GameObject Troop= Instantiate(enemyPrefab, this.transform.position, Quaternion.identity, this.transform);
        Troop.GetComponent<EnemyBehaviours>().Fox1 = fox;
        Troop.GetComponent<EnemyBehaviours>().Yelena = yelena;
        Troop.GetComponent<EnemyBehaviours>().DefaultGoal1 = defaultgoal;
        currentTroop++;
    }
    public void Enemydied()
    {
        currentTroop--;
    }
}
