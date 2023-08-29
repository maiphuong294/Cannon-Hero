using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyGun gun;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimToPlayer()
    {
        gun.AimToPlayer();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet") == true)
        {
            
            collision.gameObject.SetActive(false);
            Debug.Log("HIT");
            
            GameObject enemyAndBase = transform.parent.gameObject;
            Destroy(enemyAndBase);

            Player.Hit_Miss = 1;
            Player.Moving = true;
            Player.instance.ResetGun();

            ScoreManager.instance.currentScore++;



        }
    }

}
