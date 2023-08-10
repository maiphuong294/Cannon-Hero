using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGun : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject bulletPrefab;
    public Vector3 directionToPlayer;
    public Vector3 forceDirection;
    public float forceAmount;
  
    private float angle;//goc aim den player
    private float anglePerFrame;
    private float cnt;
    private float rotationSpeed;

    private float rotationProgress;
    private float rotationTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");//vi trong scene chi co 1 player
        directionToPlayer = Vector3.zero;
        forceDirection = Vector3.zero;
        forceAmount = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimToPlayer()
    {
        
        //direction == velocity
        directionToPlayer = Player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, transform.up);
        rb.MoveRotation(targetRotation);
        Debug.Log("Aim To Player");


        //fire-----------------------
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(directionToPlayer * forceAmount, ForceMode2D.Impulse);

    }
}
