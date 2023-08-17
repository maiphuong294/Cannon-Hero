using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private UnityEngine.Color color;
    private float fadeSpeed;
    private float shrinkSpeed;

    void Start()
    {
        fadeSpeed = 0.01f;
        shrinkSpeed = 0.01f;
        spriteRenderer = GetComponent<SpriteRenderer>();

        color = spriteRenderer.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        color.a -= fadeSpeed;
        color.a = Mathf.Clamp01(color.a);
        spriteRenderer.color = color;
        transform.localScale *= (1.0f - shrinkSpeed * Time.deltaTime);
        if (color.a == 0)
        {
            Destroy(gameObject);
        }
    }
}
