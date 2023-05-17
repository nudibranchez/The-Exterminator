using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    [SerializeField] float SpawnRad;
    float SpawnTimer, TimePassed;
    [SerializeField] GameObject[] Enemies;
    [SerializeField] float Initial, Minimum, Halftime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        SpawnTimer += Time.deltaTime;
        TimePassed += Time.deltaTime;

        float CurrentSpawnInterval;

        CurrentSpawnInterval = ((Initial-Minimum)/(TimePassed*(1/Halftime)+1))+ Minimum;

        if (SpawnTimer > CurrentSpawnInterval)
        {
            SpawnEnemy();
            SpawnTimer = 0;
        }
    }

    void SpawnEnemy()
    {
        Vector2 EnemyPos = EnemyPosition();
        GameObject Enemy = Enemies[Random.Range(0, Enemies.Length)];
        Instantiate(Enemy, EnemyPos, Quaternion.identity);
    }

    Vector2 EnemyPosition()
    {
        Vector2 Pos = Random.insideUnitCircle;

        if (Pos.magnitude == 0)
        {
            Pos = Vector2.right;
        }

        Vector2 Norm = Pos.normalized*SpawnRad;

        return (Vector2)transform.position + Norm;
    }
}
