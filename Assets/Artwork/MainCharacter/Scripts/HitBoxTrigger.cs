using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxTrigger : MonoBehaviour
{
    private GameObject P;
    private Animator a;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        a = P.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy" && (a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Outward Slash") || a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Outward Slash 0")))
        {
            Debug.Log("enemy");
            // do damage
        }

        if (other.tag == "enemy" && a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Inward Slash (1) 1"))
        {
            Debug.Log("enemy 2x");
            // do damage
        }
    }
}
