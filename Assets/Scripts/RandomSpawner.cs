using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public float startSpawnTime = 4;
    private float spawnTime;

    public Enemy enemy;
    private List<Enemy> enemies;
    float startTime;
    public static int howManySpawns = 0;
    private float range = 70.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
        startTime = Time.time;
        spawnTime = startSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime <= 0)
        {
            spawnTime = startSpawnTime;
            for (int i = 0; i < 20; i++)
            {
                Enemy spawned = Instantiate(enemy, randomLocation(range), Quaternion.identity) as Enemy;
                enemies.Add(spawned);
            }
            howManySpawns += 1;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
        if ((Time.time - startTime > 15) && (spawnTime <= 0) && (howManySpawns < 15))
        {

            Enemy spawned = Instantiate(enemy, randomLocation(range), Quaternion.identity) as Enemy;
            enemies.Add(spawned);
            howManySpawns += 1;
        }
        if ((Time.time - startTime > 30) && (spawnTime <= 0) && (howManySpawns < 20))
        {

            Enemy spawned = Instantiate(enemy, randomLocation(range), Quaternion.identity) as Enemy;
            enemies.Add(spawned);
            howManySpawns += 1;
        }
    }

    public Vector3 randomLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
