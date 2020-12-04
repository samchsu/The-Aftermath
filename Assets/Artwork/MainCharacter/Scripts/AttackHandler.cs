using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public GameObject goTerrain;

    public float dashSpeed;

    public bool canDash = true;

    public GameObject dashPoint;

    private Animator a;

    public GameObject DashBody;

    public InputHandler IH;
    public TopDownMovementHandler t;

    private Vector3 h;

    const float acceleration = 0.0097f;
    const float speedConstant = 0.15f;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();

        DashBody.SetActive(false);

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
                    hit.point = new Vector3(hit.point.x, 0.3f, hit.point.z);
                    h = hit.point;
                    a.SetTrigger("DashAttack");
                    transform.LookAt(hit.point);
                    StartCoroutine(DashClick(hit));

                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            a.SetTrigger("frontAttack");
        }
    }

    IEnumerator DashClick(RaycastHit hit)
    {
        var clone = Instantiate(dashPoint, hit.point, dashPoint.transform.rotation);
        t.moveSpeed = 3f;
        yield return new WaitForSeconds(1f);
        DashBody.SetActive(true);
        transform.LookAt(hit.point);
        while (transform.position != hit.point)
        {
            t.moveSpeed = 20f;
            Vector3 newPos = Vector3.MoveTowards(transform.position, hit.point, dashSpeed * Time.deltaTime);
            transform.position = newPos;
            transform.LookAt(hit.point);


            if (IH.enabled == false)
            {
                break;
            }
                yield return null;
        }
        DashBody.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dashPoint")
        {
            IH.enabled = false;
            transform.position = h;
            StartCoroutine(moveActive());
            Destroy(GameObject.FindWithTag("dashPoint"));
        }
    }

    IEnumerator moveActive()
    {
        if (IH.enabled == false)
        {
            t.moveSpeed = 0f;
            yield return new WaitForSeconds(0.1f);
            IH.enabled = true;
            canDash = true;
            t.moveSpeed = 15f;
        }
    }
}
