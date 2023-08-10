using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector3 direction;
    public Vector3 velo;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector3.up;
        velo = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        //direction == velocity
        direction = rb.velocity;
        Quaternion targetRotation = Quaternion.LookRotation(direction, transform.up);
        rb.MoveRotation(targetRotation);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true){
            Debug.Log("HIT");
        }
        if(collision.gameObject.CompareTag("Ground") == true)
        {
            Debug.Log("Hit the ground");
            GameObject Enemy = GameObject.Find("Enemy");
            GameObject Gun = Enemy.transform.Find("Gun").gameObject;
            EnemyGun script = Gun.GetComponent<EnemyGun>();
            script.AimToPlayer();

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
       
        }
    }
}

