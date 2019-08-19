using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade_in : MonoBehaviour
{
    private bool isFading = false;
    private SpriteRenderer spriteRenderer;
    private float fadeRate = 1f;
    private string targetScene;
    private float alpha = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            alpha += fadeRate * Time.deltaTime;
            alpha = 0.5f;
            Debug.Log(alpha);
            if (alpha >= 1f)
            {
                alpha = 1f;
                isFading = false;
                SceneManager.LoadScene(targetScene);
            }

            spriteRenderer.color = new Color(0f, 0f, 0f, 0.5f);
        }
    }

    public void DoFade(float rate, string sceneName)
    {
        isFading = true;
        fadeRate = rate;
        targetScene = sceneName;
    }
}
