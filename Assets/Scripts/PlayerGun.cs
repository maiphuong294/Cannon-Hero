using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool isOnPress;
    private float rotationSpeed;

    [SerializeField] private Vector3 forceDirection;
    private float forceAmount;

    [SerializeField] private GameObject bulletPrefab;
    void Start()
    {
        isOnPress = false;
        rotationSpeed = 15f;
        forceAmount = 10f;
        forceDirection = Vector3.up;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) == true)
        {
            isOnPress=true;          
        }
        if(isOnPress == true)
        {
            //transform.Rotate(1.0f, 0.0f, 0.0f, Space.Self);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if(Input.GetMouseButtonUp(0) == true)
        {
            //chuyen tu rotation.euler -> direction theo chieu x, y
            forceDirection.x = (float)Math.Cos(transform.rotation.eulerAngles.z * 0.0174532925);
            forceDirection.y = (float)Math.Sin(transform.rotation.eulerAngles.z * 0.0174532925);
            isOnPress = false;
            //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(forceDirection));
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.localEulerAngles));

            bullet.GetComponent<Rigidbody2D>().AddForce(forceDirection * forceAmount, ForceMode2D.Impulse);

            Debug.Log("Hit the ground");
            GameObject Enemy = GameObject.Find("Enemy");
            GameObject Gun = Enemy.transform.Find("Gun").gameObject;
            EnemyGun script = Gun.GetComponent<EnemyGun>();
            script.AimToPlayer();



        }
    }
}
