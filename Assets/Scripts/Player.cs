using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    [SerializeField] private PlayerGun gun;
    public static int Hit_Miss;
    public static bool Moving;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Hit_Miss = 0;
        Moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet") == true)
        {

            Debug.Log("GAMEOVER");
            Destroy(gameObject);

           
            PlayerPrefs.SetInt("HighScore", Mathf.Max(ScoreManager.instance.currentScore, PlayerPrefs.GetInt("HighScore")));
        }
    }

    public void ResetGun()
    {
        gun.ResetGun();
    }

    public void ReloadPlayScene()
    {
        //SceneManager.LoadScene("PlayScene");
    }
}
