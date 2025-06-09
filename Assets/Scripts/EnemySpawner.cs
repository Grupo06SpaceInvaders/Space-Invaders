using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemys_PreFab;
    public GameObject shoot_PreFab;
    private GameObject Player;
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

    public float verticalWidth = 8f;

    private float speed, cooldown, shootColdown, shootIncreaseVelocity, shootIncreaseCooldown;
    private List<GameObject> enemys;
    private float horizontalSpacing, verticalSpacing;
    private Vector3 enemySpawnPostion = new Vector3(-17, 0, 9);
    private Vector3 enemyMasterInitialPosition = new Vector3(0, 0, 0);
    private Vector3 directionMovement;

    private void Start()
    {
        directionMovement = Vector3.left;
        speed = initialSpeed;
        horizontalSpacing = 34f / ColEnemyQTD;
        verticalSpacing = verticalWidth / RowEnemyQTD;
        enemys = new List<GameObject>();
        cooldown = fowardInterval;
        bulletSpeed = bulletSpeed * 100;
        shootIncreaseVelocity = 10;
        shootIncreaseCooldown = shootIncreaseVelocity;

        Player = GameObject.FindGameObjectWithTag("Player");

        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies()
    {
        for (int i = 0; i < RowEnemyQTD; i++)
        {
            for (int j = 0; j < ColEnemyQTD; j++)
            {
                Debug.Log('a');
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


        //Cooldowns

        shootIncreaseCooldown -= Time.deltaTime;
        if (shootIncreaseCooldown <= 0)
        {
            shootInterval -= shootSpeedIncrease;
            shootIncreaseCooldown = shootIncreaseVelocity;
        }

        shootColdown -= Time.deltaTime;
        if (enemys.Count > 0)
        {
            if (shootColdown <= 0)
            {
                shootColdown = shootInterval;
                StartCoroutine(SpawnBullet());
            }
        }


        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            StartCoroutine(ChangeEnemyRol());
            cooldown = fowardInterval;
        }
    }

    IEnumerator SpawnBullet()
    {
        enemys.RemoveAll(enemy => enemy == null);
        float closerEnemy = Vector3.Distance(enemys[0].transform.position, Player.transform.position);
        int enemyToShoot = 0;
        for (int i = 0; i < enemys.Count; i++)
        {
            float distance = Vector3.Distance(enemys[i].transform.position, Player.transform.position);
            if (distance < closerEnemy)
            {
                closerEnemy = distance;
                enemyToShoot = i;
            }
        }

        GameObject shoot = Instantiate(shoot_PreFab);
        shoot.transform.position = enemys[enemyToShoot].transform.position;
        shoot.transform.LookAt(-Vector3.forward + shoot.transform.position);
        shoot.GetComponent<ShootBehavior>().damage = bulletDamage;
        shoot.GetComponent<Rigidbody>().AddForce(-Vector3.forward * bulletSpeed);

        yield return new WaitForSeconds(3);
        try
        {
            Destroy(shoot.gameObject);
        }
        finally
        {

        }

    }

    IEnumerator ChangeEnemyRol()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].transform.position += new Vector3(0, 0, -verticalSpacing);
        }
        yield return new WaitForEndOfFrame();
    }
}