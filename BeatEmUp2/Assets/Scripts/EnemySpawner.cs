using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject location1, location2;
    [SerializeField] private float spawnTimer;
    private float spawnTimerHolder;
    
    void Start()
    {

        spawnTimerHolder = spawnTimer;
    }

    
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            spawnTimer = spawnTimerHolder;
            int randomV = Random.Range(0, 10);
            if (randomV % 2.0f == 0)
            Instantiate(enemyPrefab, location1.transform.position, Quaternion.identity);
            else
            Instantiate(enemyPrefab, location2.transform.position, Quaternion.identity);
            

        }
    }
}
