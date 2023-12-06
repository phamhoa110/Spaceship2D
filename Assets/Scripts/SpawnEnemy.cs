using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int maxEnemies = 10;
    private int numberEnemyIncrease = 1;
    private int enemyCount = 0;
    private int enemySpawned;
    private bool checkSpawned = false;

    public GameObject bossPrefab;
    public GameObject enemyPrefab;
    public Transform spawnPosition;


    private void Start()
    {
        Instantiate(bossPrefab, spawnPosition.position, spawnPosition.rotation);

        InvokeRepeating("Spawn", 0.3f, 5f);
    }

    private void Update()
    {
        if(enemySpawned == 1 && !checkSpawned)
        {
            SpawnBoss();

            checkSpawned = true;
        }
        Debug.Log(enemySpawned);
    }
    void Spawn()
    {
        Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
        enemyCount++;
        if (enemyCount == numberEnemyIncrease)
        {
            numberEnemyIncrease += 1;
            enemyCount = 0;

            if (numberEnemyIncrease > maxEnemies)
            {
                CancelInvoke("Spawn");
            }

        }
        else
        {
            Invoke("Spawn", 0.3f);
            enemySpawned++;
        }
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, spawnPosition.position, spawnPosition.rotation);
    }
}
