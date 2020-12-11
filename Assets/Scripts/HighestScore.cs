using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighestScore : MonoBehaviour
{
    private static HighestScore instance;
    public static HighestScore Instance { get { return instance; } }

    public int killScore;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
