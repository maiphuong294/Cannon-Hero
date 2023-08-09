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
}

