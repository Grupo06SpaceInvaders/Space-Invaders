using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemys_PreFab;
    public GameObject shoot_PreFab;
    public float initialSpeed;
    public float speedIncrease;
    public float movementVariation = 3f;
    public int ColEnemyQTD = 11;
    public int RowEnemyQTD = 5;
    public int bulletSpeed = 25;
    public float bulletDamage = 25;
    public float fowardInterval = 20f;
    public float shootInterval = 2f;
    public float shootSpeedIncrease = 0.1f;
    public float quantEnemy;

    private float speed, cooldown, shootColdown;
    private List<GameObject> enemys;
    private float horizontalSpacing, verticalSpacing;
    private Vector3 enemySpawnPostion = new Vector3(-17, 0, 9);
    private Vector3 enemyMasterInitialPosition = new Vector3(0, 0, 0);
    private Vector3 directionMovement;
    private Vector3 startSpawnPosition = new Vector3(-3f, 0f, 12f);
    private float horizontalSpacing = 1.5f;
    private float zSpacing = 0f;
    private int enemyCounter;

    private void Start()
    {
        directionMovement = Vector3.left;
        speed = initialSpeed;
        horizontalSpacing = 34f / ColEnemyQTD;
        verticalSpacing = 10f / RowEnemyQTD;
        enemys = new List<GameObject>();
        cooldown = fowardInterval;
        bulletSpeed = bulletSpeed * 100;

        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies()
    {
        for (int i = 0; i < RowEnemyQTD; i++)
        {
            for (int j = 0; j < ColEnemyQTD; j++)
            {
                GameObject enemy = Instantiate(enemys_PreFab[i], gameObject.transform);
                enemys.Add(enemy);

                enemy.transform.position = enemySpawnPostion + new Vector3(horizontalSpacing * j + 1, 0, -verticalSpacing * i);
            }
        }
    }

    private void FixedUpdate()
    {
        Rigidbody enemys_rigidBody = gameObject.GetComponent<Rigidbody>();

        if (gameObject.transform.position.x > (movementVariation + enemyMasterInitialPosition.x)) { directionMovement = Vector3.left; }
        if (gameObject.transform.position.x < (-movementVariation + enemyMasterInitialPosition.x)) { directionMovement = Vector3.right; }
        enemys_rigidBody.AddForce(speed * directionMovement);
        speed += speedIncrease * Time.deltaTime;

        quantEnemy = enemys.Count;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        shootColdown -= Time.deltaTime;
        if (shootColdown <= 0)
        {
            if (shootInterval >= 0.1f)
            {
                shootInterval -= -shootSpeedIncrease;
            }
            else
            {
                shootInterval = 0.1f;
            }
            shootColdown = shootInterval;
            SpawnBullet();
        }
        if (cooldown <= 0)
        {
            StartCoroutine(ChangeEnemyRol());
            cooldown = fowardInterval;
        }
    }

    void SpawnBullet()
    {
        enemys.RemoveAll(enemy => enemy == null);
        int enemyToShoot = UnityEngine.Random.Range(0, enemys.Count);

        GameObject shoot = Instantiate(shoot_PreFab);
        shoot.transform.position = enemys[enemyToShoot].transform.position;
        shoot.transform.LookAt(-Vector3.forward + shoot.transform.position);
        shoot.GetComponent<ShootBehavior>().damage = bulletDamage;
        shoot.GetComponent<Rigidbody>().AddForce(-Vector3.forward * bulletSpeed);
    }

    IEnumerator ChangeEnemyRol()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemyCounter++;
            if(i==3)
            {
                enemyCounter=0;
                startSpawnPosition = new Vector3(-1.5f, 0f, 10f);
            }
            Vector3 spawnPosition = startSpawnPosition + new Vector3(horizontalSpacing * enemyCounter, 0f, 0f);

            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            EnemyCode enemySpawned = spawnedEnemy.GetComponent<EnemyCode>();
            enemySpawned.enemy = enemy.transform;
            
            yield return new WaitForSeconds(spawnInterval);
        }
        yield return new WaitForEndOfFrame();
    }
}
