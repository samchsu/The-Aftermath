using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float enemyHealth = 100f;
    public Enemy enemyAI;
    private CapsuleCollider CC;

    public int i = 1;

    public Player player;
    public AudioSource playerHurt;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = gameObject.GetComponent<Enemy>();
        CC = gameObject.GetComponent<CapsuleCollider>();

        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            if(i == 1)
            {
                enemyAI.EnemyDeath();
                CC.isTrigger = true;
                StartCoroutine(playPS());
                Destroy(this.gameObject, 5);
                i = 0;
            }
        }
    }

    IEnumerator playPS()
    {
        var emission = gameObject.GetComponent<ParticleSystem>().emission;
        emission.enabled = true;
        yield return new WaitForSeconds(1f);
        emission.enabled = false;
    }

    public void dealDmg()
    {
        player.playerHealth -= .5f;
        if(player.playerHealth >= 0)
        {
            playerHurt.Play();
        }
    }
}
