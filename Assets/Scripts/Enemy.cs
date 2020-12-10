using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent enemy;
    public Player player;

    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);


        if (distance > 1.6 && !isDead)
        {
            transform.LookAt(player.transform.position);
            enemy.updatePosition = true;
            enemy.SetDestination(player.transform.position);
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
        }
        else
        {
            transform.LookAt(transform.position);
            enemy.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
        }
    }

    public void EnemyDeath()
    {
        transform.LookAt(transform.position);
        isDead = true;
        anim.SetTrigger("isDead");
    }
}
