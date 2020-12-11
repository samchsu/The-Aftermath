using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabKillCount : MonoBehaviour
{

    public TMP_Text kills;

    // Start is called before the first frame update
    void Start()
    {
        kills = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        kills.text = PlayerPrefs.GetInt("HighestKills", 0).ToString();
    }
}
