using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    private Rigidbody myRB;
    public float moveSpeed;
    public NavMeshAgent enemy;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.stoppingDistance < 5f)
        {
            anim.SetTrigger("Attack");
        }
        if (enemy.destination == player.transform.position)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
            transform.LookAt(player.transform.position);
            //enemy.destination = player.transform.position;
        }
    }

    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }
}
