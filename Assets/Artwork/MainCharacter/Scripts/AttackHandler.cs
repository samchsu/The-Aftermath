using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public GameObject goTerrain;

    public float dashSpeed;

    public bool canDash = true;

    public Animator a;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash)
        {
            if (Input.GetMouseButtonDown(1))
            {
                canDash = false;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (goTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    a.SetTrigger("DashAttack");
                    transform.LookAt(hit.point);
                    StartCoroutine(DashClick(hit));

                }
            }
        }

    }

    IEnumerator DashClick(RaycastHit hit)
    {
        while (transform.position != hit.point)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, hit.point, dashSpeed * Time.deltaTime);
            transform.position = newPos;

            yield return null;
        }
        canDash = true;
    }
}
