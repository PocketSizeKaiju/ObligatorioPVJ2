using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightsScript : MonoBehaviour
{
    private double delta;

    [Header("Sonido de luz/fuego")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip lightSound;

    [Header("Duración extra del sonido")]
    [SerializeField] private float soundDurationAfterRelease = 0.7f;

    private float soundTimer;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (GameState.IsGameplayBlocked)
        {
            StopLightSound();
            return;
        }

        bool ctrlPressed = Keyboard.current.ctrlKey.IsPressed();

        // Visual igual que antes
        GetComponent<BoxCollider2D>().enabled = ctrlPressed;
        GetComponent<Renderer>().enabled = ctrlPressed;

        // Sonido
        if (ctrlPressed)
        {
            soundTimer = soundDurationAfterRelease;
            PlayLightSound();
        }
        else
        {
            soundTimer -= Time.deltaTime;

            if (soundTimer <= 0)
            {
                StopLightSound();
            }
        }

        delta += Time.deltaTime;

        if (delta > 5 && ctrlPressed)
        {
            Settings.Instance.PlayerLife -= 1;
            delta = 0;
        }
        else if (!ctrlPressed)
        {
            delta = 0;
        }
    }

    private void PlayLightSound()
    {
        if (audioSource == null || lightSound == null)
            return;

        if (!audioSource.isPlaying)
        {
            audioSource.clip = lightSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void StopLightSound()
    {
        if (audioSource == null)
            return;

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}