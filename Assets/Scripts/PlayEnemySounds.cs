using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnemySounds : MonoBehaviour
{
    public AudioSource grunt;
    public AudioSource step;

    public Player p;

    void Start()
    {
        p = FindObjectOfType<Player>();
    }

    public void playGrunt()
    {
        if(p. playerHealth >= 0)
        {
            grunt.Play();
        }
    }

    public void playStep()
    {
        step.Play();
    }
}
