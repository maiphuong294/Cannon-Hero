using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool isOnPress;
    public bool isOnReset;
    private float rotationSpeed;

    [SerializeField] private Vector3 forceDirection;
    private float forceAmount;

    [SerializeField] private GameObject bulletPrefab;
    void Start()
    {
        isOnPress = false;
        isOnReset = false;
        rotationSpeed = 30f;
        forceAmount = 10f;
        forceDirection = Vector3.up;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnReset == true)
        {
            transform.Rotate(Vector3.back, rotationSpeed * 6f * Time.deltaTime);
            if (transform.rotation.eulerAngles.z <= 1.5f)//de 0f thi quay mai khong dung????
            {
                isOnReset = false;
            }
            return;
        }
        if (Input.GetMouseButtonDown(0) == true && !IsOverUI())
        {
            isOnPress=true;          
        }
        if (isOnPress == true && transform.rotation.eulerAngles.z < 90f) 
        {
            //transform.Rotate(1.0f, 0.0f, 0.0f, Space.Self);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if(Input.GetMouseButtonUp(0) == true && !IsOverUI())
        {
            //chuyen tu rotation.euler -> direction theo chieu x, y
            forceDirection.x = (float)Math.Cos(transform.rotation.eulerAngles.z * 0.0174532925);
            forceDirection.y = (float)Math.Sin(transform.rotation.eulerAngles.z * 0.0174532925);
            isOnPress = false;

            GameObject BulletStart = transform.Find("Bullet Start").gameObject;
            GameObject bullet = Instantiate(bulletPrefab, BulletStart.transform.position, Quaternion.Euler(transform.localEulerAngles));

            bullet.GetComponent<Rigidbody2D>().AddForce(forceDirection * forceAmount, ForceMode2D.Impulse);

        }
        
    }

    public void ResetGun()
    {
        isOnReset = true;
    }
    public static bool IsOverUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
