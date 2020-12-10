using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float playerHealth;
    public barSlideHandler b;

    public int playerKills;
    public TMP_Text killText;

    public int killCombo = 0;

    private AttackHandler AH;

    private Animator a;
    // Start is called before the first frame update
    void Start()
    {
        b.SetMaxCD(playerHealth);

        playerKills = 0;

        AH = gameObject.GetComponent<AttackHandler>();

        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        b.SetCD(playerHealth);

        killText.text = playerKills.ToString();

        if (killCombo >= 3)
        {
            if (playerHealth <= 4.9f)
            {
                playerHealth += .25f;
            }
            killCombo = 0;
        }

        if (playerHealth <= 0)
        {
            a.SetTrigger("dead");
            var emission = gameObject.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
            gameObject.GetComponent<playLightAttackPS>().enabled = false;
            gameObject.GetComponent<AttackHandler>().enabled = false;
            gameObject.GetComponent<TopDownMovementHandler>().enabled = false;
        }
    }

    public void addKill()
    {
        if(AH.barCountdown <= 10)
        {
            AH.barCountdown += 0.2f;
        }
        playerKills += 1;
        killCombo += 1;
    }

}
