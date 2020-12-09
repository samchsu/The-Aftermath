using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSoundEffects : MonoBehaviour
{
    public AudioSource dash;
    public AudioSource frontAttack;
    private Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playDashCharge()
    {
        dash.pitch = 4;
        dash.Play(0);
    }

    public void playDash()
    {
        dash.pitch = 1;
        dash.Play(0);
        dash.pitch = 0.5f;
        frontAttack.pitch = 0.5f;
        frontAttack.Play(0);
    }

    public void playFrontAttack()
    {
        frontAttack.pitch = 1f;
        frontAttack.Play(0);
    }
}
