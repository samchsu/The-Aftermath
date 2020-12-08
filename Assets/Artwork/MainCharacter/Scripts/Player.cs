using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth;
    public barSlideHandler b;

    // Start is called before the first frame update
    void Start()
    {
        b.SetMaxCD(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        b.SetCD(playerHealth);

    }

}
