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
        if (Input.GetMouseButtonUp(0) == true)
        {
            Debug.Log("StartPlaye");
            gameObject.SetActive(false);
        }
    }

}
