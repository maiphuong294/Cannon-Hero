using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPanel : MonoBehaviour
{
  
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0) == true && SceneManager.currentScene == Scene.Menu) 
        {
            Debug.Log("StartPlaye");
            StartCoroutine("ChangeState");
            UIManager.instance.CloseMenu();
        }
    }
     
    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.currentScene = Scene.Play;
        gameObject.SetActive(false);
    }

    

}
