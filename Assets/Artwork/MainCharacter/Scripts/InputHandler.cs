using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Animator a;
    const float acceleration = 0.0097f;
    const float speedConstant = 0.15f;
    float speed;

    public Vector2 InputVector { get; private set; }

    public Vector3 MousePosition { get; private set; }

    public bool moveBool = true;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);

        MousePosition = Input.mousePosition;

        if (moveBool)
        {
            move();
        }
    }

    public void move()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            speed += acceleration;
        }
        else
        {
            speed -= acceleration;
        }

        speed = Mathf.Clamp(speed, 0, 1);
        a.SetFloat("Blend", speed);
    }
}
