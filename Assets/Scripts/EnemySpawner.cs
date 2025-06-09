using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int numberOfEnemies = 6;

    private Vector3 startSpawnPosition = new Vector3(-3f, 0f, 12f);
    private float horizontalSpacing = 1.5f;
    private float zSpacing = 0f;

    private bool hasStartedSpawning = false;

    private float spawnInterval = 0.01f;

    private int enemyCounter = 0;

    void FixedUpdate()
    {
        if (GlobalVariables.enemyKilled % 6==0)
        {
            hasStartedSpawning = false;
        }
    }

    void OnEnable()
    {
        if (!hasStartedSpawning)
        {
            StartCoroutine(SpawnEnemies());
            hasStartedSpawning = true;
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemyCounter++;
            if (i == 3)
            {
                enemyCounter = 0;
                startSpawnPosition = new Vector3(-3f, 0f, 12f);
            }
            Vector3 spawnPosition = startSpawnPosition + new Vector3(horizontalSpacing * i, 0f, 0f);

            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            //EnemyCode enemySpawned = spawnedEnemy.GetComponent<EnemyCode>();
            //enemySpawned.enemy = enemy.transform;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}