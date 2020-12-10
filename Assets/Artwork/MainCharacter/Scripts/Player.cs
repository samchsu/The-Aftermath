using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerHealth;
    public barSlideHandler b;

    public int playerKills;
    public TMP_Text killText;

    // Start is called before the first frame update
    void Start()
    {
        b.SetMaxCD(playerHealth);

        playerKills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        b.SetCD(playerHealth);

        killText.text = playerKills.ToString();
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
    }

    public void addKill()
    {
        playerKills += 1;
    }
}
