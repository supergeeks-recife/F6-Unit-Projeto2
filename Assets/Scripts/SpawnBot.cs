using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnBot : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    void Start()
    {
        spawnPoint = this.transform;
        for(int i = 0; i <= 7; i++)
        {
            SpawnEnemy();
        }
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}