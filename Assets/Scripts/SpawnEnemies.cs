using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Enemy enemy;
    private List<Enemy> enemies;

    public int numEnemies = 25;
    private float range = 70.0f;

    void Start()
    {
        enemies = new List<Enemy>();

        for (int index = 0; index < numEnemies; index++)
        {
            Enemy spawned = Instantiate(enemy, randomLocation(range), Quaternion.identity) as Enemy;
            enemies.Add(spawned);
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
