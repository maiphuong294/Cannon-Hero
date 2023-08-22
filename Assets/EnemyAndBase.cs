using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndBase : MonoBehaviour
{
    // Start is called before the first frame update
    private float endPosX;
    private bool needMove;
    void Start()
    {
        endPosX = Random.Range(1f, 2f);
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
                if (transform.position.x < endPosX)
                {
                    needMove = false;
                    Player.Moving = false;
                }
            }
        }
        
    }
}
