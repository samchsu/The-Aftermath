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

    public UIManager _ui_manager;
    public List<GameObject> prefabsToInst;
    private List<GameObject> uiCanvases;
    private Dictionary<string, GameObject> uiDictionary;

    private string myActiveScene = "UI_Manager";
    public Button aboutButton;
    public Button backButton;
    public Button playButton;
    public Button quitButton;
    public Button tryagainButton;

    public Animator a;

    public void Awake()
    {
        if (Instance == null)
        {
            uiCanvases = new List<GameObject>();
            uiDictionary = new Dictionary<string, GameObject>();

            Instance = this;
            DontDestroyOnLoad(this);

            myActiveScene = SceneManager.GetActiveScene().name;

            foreach (GameObject prefab in prefabsToInst)
            {
                GameObject toAdd = Instantiate(prefab);
                toAdd.name = prefab.name;
                toAdd.transform.SetParent(transform);
                uiCanvases.Add(toAdd);
                uiDictionary.Add(toAdd.name.ToString(), toAdd);
            }

            if (myActiveScene == "UI_Manager")
            {
                foreach (GameObject canvasgo in uiCanvases)
                {
                    canvasgo.SetActive(false);
                }

                GameObject go = uiDictionary["Canvas_Main"];
                go.SetActive(true);

                UnityEngine.Debug.Log("Entering Canvas_Main");

                playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
                playButton.onClick.AddListener(() => StartCoroutine(playPS()));

                aboutButton = GameObject.FindGameObjectWithTag("AboutButton").GetComponent<Button>();
                aboutButton.onClick.AddListener(() => SceneManager.LoadScene(2));

                quitButton = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();
                quitButton.onClick.AddListener(() => QuitGame());

                a = GameObject.FindGameObjectWithTag("PS").GetComponent<Animator>();
                a.SetTrigger("zoom");

                myActiveScene = "UI_Manager";
            }
        }
        else
        {
            Destroy(gameObject); //Kills all other versions of gameobject
        }
    }

    IEnumerator playPS()
    {
        a = GameObject.FindGameObjectWithTag("PS").GetComponent<Animator>();
        a.SetTrigger("zoom");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    public void LoadSceneByNumber(int sceneNumber)
    {
        UnityEngine.Debug.Log("sceneBuildIndex to load: " + sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }

    void OnLevelWasLoaded(int level)
    {
        if (uiDictionary == null) return;
        UnityEngine.Debug.Log("On Level was loaded with level = " + level + " ...");

        if (level == 0)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(true);

            go = uiDictionary["Canvas_About"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);

        }

        if (level == 1)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);

        }

        if (level == 2)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_About"];
            go.SetActive(true);
            //if (Input.GetMouseButtonDown(0))
            //{
            //    SceneManager.LoadScene(0);
            //}
            backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
            backButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }
        if (level == 3)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_About"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(true);
            playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
            playButton.onClick.AddListener(() => SceneManager.LoadScene(1));
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
