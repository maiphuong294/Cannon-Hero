using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector3 direction;
    public Vector3 velo;
    private float veloMin;

    [SerializeField] private GameObject whiteTrailPrefab;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        rb = GetComponent<Rigidbody2D>();
        direction = Vector3.up;
        velo = Vector3.up;
        veloMin = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //direction == velocity
        direction = rb.velocity;
        Quaternion targetRotation = Quaternion.LookRotation(direction, transform.up);
        rb.MoveRotation(targetRotation);


        //them white trail
        if(rb.velocity.magnitude > veloMin)
        {
            Instantiate(whiteTrailPrefab, transform.position, Quaternion.identity);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") == true)
        {
            Debug.Log("Hit the ground");
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            GameOver();
       
        }
        
        if (collision.gameObject.CompareTag("Head") == true)
        {
            ScoreManager.instance.currentScore += 2;
            Debug.Log("HEADSHOT");
            UIManager.instance.HeadShot();
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            return;
            
        }
        if (collision.gameObject.CompareTag("Body") == true)
        {
            ScoreManager.instance.currentScore++;
            Debug.Log("Hit but not headshot");
            UIManager.instance.Hit();
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;

            return;

        }
        //bug hit sau do headshot


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            GameOver();
        }

        //ban vao head duoc them 1 diem
        
    }

    public void GameOver()
    {
        Debug.Log("gameOver");
        GameObject enemy = GameObject.Find("Enemy");
        if (enemy != null && Player.instance != null) enemy.GetComponent<Enemy>().AimToPlayer();
        UIManager.instance.Miss();
        GameOverPanel = Canvas.transform.Find("GameOver Panel").gameObject;
        GameOverPanel.SetActive(true);
      
        
    }

   
}

