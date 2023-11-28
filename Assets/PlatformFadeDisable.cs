using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFadeDisable : MonoBehaviour
{
    public float fadeDuration = 2.0f;  // Duration of the fade
    public float fadeDelay = 3.0f;     // Delay before the fade starts
    private float enableDelay = 2.0f;
    private float fadeTimer = 0.0f;
    private float enableTimer = 0.0f;

    private Renderer renderer;
    private Collider collider;

    private bool isFading = false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (isFading)
        {
            // Start fading after the delay
            fadeTimer += Time.deltaTime;
            if (fadeTimer >= fadeDelay)
            {
                float progress = (Time.time - (fadeTimer - fadeDelay)) / fadeDuration;
                Color currentColor = renderer.material.color;
                currentColor.a = Mathf.Lerp(1.0f, 0.0f, progress);
                renderer.material.color = currentColor;

                if (progress >= 1.0f)
                {
                    isFading = false;
                    renderer.enabled = false;
                    collider.enabled = false;
                    StartCoroutine(EnableAfterDelay(enableDelay));
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartFade();
        }
    }

    void StartFade()
    {
        isFading = true;
        fadeTimer = 0.0f;
    }

    IEnumerator EnableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        renderer.enabled = true;
        collider.enabled = true;
        isFading = false; // Reset the fading state
    }
}
