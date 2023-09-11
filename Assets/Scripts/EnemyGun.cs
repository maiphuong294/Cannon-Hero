using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyGun : MonoBehaviour
{
    private Rigidbody2D rb;

    //[SerializeField] private GameObject Player;
    [SerializeField] private GameObject bulletPrefab;
    public Vector3 directionToPlayer;
    public Vector3 forceDirection;
    public Quaternion startRotation;
    public float forceAmount;


    public float rotationProgress;
    public float rotationTime;

    private bool isAim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Player = GameObject.Find("Player");//vi trong scene chi co 1 player
        directionToPlayer = Vector3.zero;
        forceDirection = Vector3.zero;
        forceAmount = 4f;

        rotationTime = 0.7f;
        rotationProgress = 0f;
        isAim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotationProgress < 1 && isAim == true)
        {
            rotationProgress += Time.deltaTime / rotationTime;
            rotationProgress = Mathf.Clamp01(rotationProgress);

            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, transform.up);
            rb.MoveRotation(Quaternion.Slerp(startRotation, targetRotation, rotationProgress));
            if(rotationProgress == 1)
            {
                Fire();
                isAim = false;
            }
        }
    }
    

    public void AimToPlayer()
    {
        if(Player.instance != null)
        {
            isAim = true;
            //direction == velocity

            directionToPlayer = Player.instance.transform.position - transform.position;
            startRotation = transform.rotation;
            Debug.Log("Aim To Player");
        }
        


        
    }

    public void Fire()
    {
        //fire-----------------------
        Debug.Log("Fire" + Time.frameCount);
        GameObject bulletStart = transform.Find("Bullet Start").gameObject;
        GameObject bullet = Instantiate(bulletPrefab, bulletStart.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(directionToPlayer * forceAmount, ForceMode2D.Impulse);

    }

    
}
