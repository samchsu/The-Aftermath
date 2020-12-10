using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float enemyHealth = 100f;
    public Enemy enemyAI;

    public int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = gameObject.GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            if(i == 1)
            {
                enemyAI.EnemyDeath();
                
                Destroy(this.gameObject, 5);
                i = 0;
            }
        }
    }

}
