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
    void Start()
    {
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
        if (collision.gameObject.CompareTag("Enemy") == true){
            Debug.Log("HIT");
        }
        if(collision.gameObject.CompareTag("Ground") == true)
        {
            Debug.Log("Hit the ground");
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            GameOver();
       
        }
        

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("gameOver");
        GameObject enemy = GameObject.Find("Enemy");
        enemy.GetComponent<Enemy>().AimToPlayer();
    }

   
}

