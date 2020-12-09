using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float enemyHealth = 100f;
    public Enemy enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = FindObjectOfType<Enemy>();    
    }

    public void damageHealth(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            enemyDead();
        }
    }

    void enemyDead()
    {
        enemyAI.EnemyDeath();
        Destroy(gameObject, 10);
    }
}
