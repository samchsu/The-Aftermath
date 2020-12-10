using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Enemy enemy;
    private List<Enemy> enemies;

    public int numEnemies = 25;
    private float range = 70.0f;

    private int i;
    void Start()
    {
        enemies = new List<Enemy>();
        i = 0;
    }

    void Update()
    {
        if (i <= numEnemies)
        {
            Enemy spawned = Instantiate(enemy, randomLocation(range), Quaternion.identity) as Enemy;
            enemies.Add(spawned);
            i += 1;
            if (spawned.isDead)
            {
                i -= 1;
            }
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
