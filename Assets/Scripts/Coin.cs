using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f), ForceMode2D.Impulse);
        spriterenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("Delete");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.5f);
        for(int i = 1; i <= 100; i++)
        {
            Color color = spriterenderer.color;
            color.a = Mathf.Max(color.a - 0.01f, 0f);
            spriterenderer.color = color;
            yield return null;
        }

        Destroy(gameObject);
        
    }
}
