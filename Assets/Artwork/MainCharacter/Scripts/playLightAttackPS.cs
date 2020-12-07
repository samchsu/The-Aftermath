using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playLightAttackPS : MonoBehaviour
{
    private GameObject P;
    private Animator a;
    private GameObject frontAttackPS;
    private GameObject frontAttackPS2;
    public float y;
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
        y = transform.rotation.y;
    }


    IEnumerator playFrontAttackPS1()
    {

        if (a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Outward Slash") || a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Inward Slash (1) 1"))
        {
            Debug.Log("Jumping");
            var clone = Instantiate(frontAttackPS, transform.position, transform.rotation);
            clone.transform.parent = P.transform;
            yield return new WaitForSeconds(1f);
            Destroy(clone);
        }
    }

    IEnumerator playFrontAttackPS2()
    {

        if (a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Outward Slash 0") || a.GetCurrentAnimatorStateInfo(1).IsName("Stable Sword Inward Slash (1) 1"))
        {
            Debug.Log("NOT Jumping");
            var clone = Instantiate(frontAttackPS2, transform.position, transform.rotation);
            clone.transform.parent = P.transform;
            yield return new WaitForSeconds(1f);
            Destroy(clone);
        }
    }
}
