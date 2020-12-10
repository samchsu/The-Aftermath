using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// UIManager referenced to Professor S. Price's code 
//Name: Samuel Hsu
//Class: CS583
//Professor: S. Price

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    private string myActiveScene = "ActiveNow";
    public Button aboutButton;
    public Button backButton;
    public Button playButton;
    public Button quitButton;
    public Button tryagainButton;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

            myActiveScene = SceneManager.GetActiveScene().name;

            if (myActiveScene == "ActiveNow")
            {
                UnityEngine.Debug.Log("Entering Main Scene");

                playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
                playButton.onClick.AddListener(() => SceneManager.LoadScene(1));

                aboutButton = GameObject.FindGameObjectWithTag("AboutButton").GetComponent<Button>();
                aboutButton.onClick.AddListener(() => SceneManager.LoadScene(2));

                quitButton = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();
                quitButton.onClick.AddListener(() => QuitGame());

                myActiveScene = "ActiveNow";
            }
        }
        else
        {
            Destroy(gameObject); //Kills all other versions of gameobject
        }
    }

    public void LoadSceneByNumber(int sceneNumber)
    {
        UnityEngine.Debug.Log("sceneBuildIndex to load: " + sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }

    void OnLevelWasLoaded(int level)
    {
        UnityEngine.Debug.Log("On Level was loaded with level = " + level + " ...");

        if (level == 1)
        {
        }

        if (level == 2)
        {
            backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
            backButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }
        if (level == 3)
        {
            backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
            backButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }
        if (level == 4)
        {
            backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
            backButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }
        if (level == 5)
        {
            backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
            backButton.onClick.AddListener(() => SceneManager.LoadScene(0));
            tryagainButton = GameObject.FindGameObjectWithTag("TryagainButton").GetComponent<Button>();
            tryagainButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        }
    }
    public void QuitGame()
    {
        UnityEngine.Debug.Log("Game has quitted");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
