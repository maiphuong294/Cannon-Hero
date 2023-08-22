using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{


    //private float velocity;
    private static bool needMove;

    void Start()
    {
        //velocity = 3f;
        needMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Moving == true)
        {
            if (needMove == true)
            {

                transform.Translate(Vector2.left * Time.deltaTime);
                if (transform.position.x <= -4.88f)
                {
                    transform.position = new Vector3(4.9f, -4f, 0f);
                }
            }
        }     

    }



}
