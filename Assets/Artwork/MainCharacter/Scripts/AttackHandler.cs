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

    public float coolDownTime;
    private float countdown;
    private float barCountdown;
    public TrailRenderer tr;
    public ParticleSystem p;
    public barSlideHandler b;
    public ParticleSystem UI;
    // Start is called before the first frame update
    void Start()
    {
        barCountdown = coolDownTime;
        a = GetComponent<Animator>();

        DashBody.SetActive(false);

        b.SetMaxCD(coolDownTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                barCountdown += Time.deltaTime;
            }
            if(countdown < 0)
            {
                countdown = 0;
            }
            if(countdown == 0)
            {
                tr.startColor = new Color(0.75f, 0f, 0.28f);
                var main = p.main;
                main.startColor = new Color(0.75f, 0f, 0.28f);
                var mainUI = UI.main;
                mainUI.startColor = new Color(0.75f, 0f, 0.28f);
            }
            else
            {
                tr.startColor = new Color(0f, 0f, 0f);
                var main = p.main;
                main.startColor = new Color(0f, 0f, 0f);
                var mainUI = UI.main;
                mainUI.startColor = new Color(0f, 0f, 0f);
            }
            if (Input.GetMouseButtonDown(1) && countdown == 0)
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
                countdown = coolDownTime;
                barCountdown = 0;
            }
        }
        b.SetCD(barCountdown);
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

        if(other.tag == "wall")
        {
            IH.enabled = false;
            StartCoroutine(moveActive());
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
