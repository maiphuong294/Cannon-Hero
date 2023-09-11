using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance {  get; private set; }
    public int currentScore;

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
   
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
