using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_out : MonoBehaviour
{
    private bool isFading = false;
    private SpriteRenderer spriteRenderer;
    private float fadeRate = 1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DoFade(1f);
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = spriteRenderer.color;
        if (isFading)
        {
            currentColor.a -= fadeRate * Time.deltaTime;
            if (currentColor.a <= 0f)
            {
                currentColor.a = 0f;
                isFading = false;
            }

            spriteRenderer.color = currentColor;
        }
    }

    void DoFade(float rate)
    {
        isFading = true;
        fadeRate = rate;
    }
}
