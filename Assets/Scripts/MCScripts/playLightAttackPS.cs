using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playLightAttackPS : MonoBehaviour
{
    private GameObject P;
    private Animator a;
    private GameObject frontAttackPS;
    private GameObject frontAttackPS2;
    public GameObject HitBox;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        a = P.GetComponent<Animator>();
        frontAttackPS = GameObject.Find("frontAttackSlash");
        frontAttackPS2 = GameObject.Find("frontAttackSlash2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            a.SetTrigger("frontAttack");
        }
    }


    IEnumerator playFrontAttackPS1()
    {

        if (a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Outward Slash"))
        {
            var clone = Instantiate(frontAttackPS, transform.position, transform.rotation);
            clone.transform.parent = P.transform;
            a.SetInteger("frontAttack2", 1);
            yield return new WaitForSeconds(1f);
            Destroy(clone);
        }
    }

    IEnumerator playFrontAttackPS2()
    {

        if (a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Outward Slash 0"))
        {
            var clone = Instantiate(frontAttackPS2, transform.position, transform.rotation);
            clone.transform.parent = P.transform;
            a.SetInteger("frontAttack2", 0);
            yield return new WaitForSeconds(1f);
            Destroy(clone);
        }
    }

    IEnumerator playDashAttackPS()
    {

        if (a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Inward Slash (1) 1"))
        {
            var clone1 = Instantiate(frontAttackPS, transform.position, transform.rotation);
            var clone2 = Instantiate(frontAttackPS2, transform.position, transform.rotation);
            clone1.transform.parent = P.transform;
            clone2.transform.parent = P.transform;
            yield return new WaitForSeconds(1f);
            Destroy(clone1);
            Destroy(clone2);
        }
    }

    IEnumerator hitBoxOn()
    {
        HitBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        HitBox.SetActive(false);
    }
}
