using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovementHandler : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera cam;

    private bool RotateTowardsMouse = false;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //move
        var movementVector = MoveTowardTarget(targetVector);

        //rotate
        if (!RotateTowardsMouse)
        {
            RotateToward(movementVector);
        }
        else
        {
            RotateTowardMouse();
        }
    }
    private void RotateTowardMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray r = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(r, out hitDist))
        {
            Vector3 targetPoint = r.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
    }

    private void RotateToward(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }

        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
        
    }
}
