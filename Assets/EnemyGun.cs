using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private GameObject Player;
    public Vector3 directionToPlayer;
  
    private float angle;//goc aim den player
    private float anglePerFrame;
    private float cnt;
    private float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");//vi trong scene chi co 1 player
        directionToPlayer = Vector3.zero;
 
        anglePerFrame = 0f;
        angle = 0f;
        cnt = 0f;
        rotationSpeed = 1f;

   
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
    }
}
