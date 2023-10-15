using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Menu,
    Play, 
    Pause,
    GameOver
}

public class SceneController : MonoBehaviour
{
    public static SceneController instance { get; private set; }
    public static Scene currentScene;

    [SerializeField] private GameObject GameOverPanel;
    void Start()
    {
        currentScene = Scene.Menu;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnReplayButton()
    {
        currentScene = Scene.Play;
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("PlayScene");

    }
    public void OpenGameOverPanel()
    {
        currentScene = Scene.GameOver;
        GameOverPanel.SetActive(true);
        Debug.Log("OpenGameOverPanel");
       
    }
    
}
