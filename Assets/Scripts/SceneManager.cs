using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scene
{
    Menu,
    Play, 
    Pause
}

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance { get; private set; }
    public static Scene currentScene;
    void Start()
    {
        currentScene = Scene.Play;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
