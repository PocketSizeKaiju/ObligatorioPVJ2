using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class doorOpening : MonoBehaviour
{
    public GameObject doorOpener;

    public bool isOpen;
    public bool playerNearby;

    [Header("Sonido de puerta")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorOpenSound;

    [Header("Sonido puerta cerrada")]
    [SerializeField] private AudioClip doorClosedSound;
    [SerializeField] private float doorClosedSoundDuration = 1f;
    [SerializeField] private float closedSoundCooldown = 0.5f;

    [Header("Duración de apertura")]
    [SerializeField] private float doorOpenDuration = 3f;

    private bool _alreadyOpened;
    private float _lastClosedSoundTime = -999f;
    private Coroutine _closedSoundCoroutine;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerNearby = true;
        }
        else if (other.gameObject == doorOpener)
        {
            isOpen = true;
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerNearby = false;
        }
        else if (other.gameObject == doorOpener)
        {
            isOpen = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !isOpen && !_alreadyOpened)
        {
            PlayClosedDoorSound();
        }
    }

    public void Update()
    {
        if (isOpen &&
            playerNearby &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (_alreadyOpened)
            return;

        _alreadyOpened = true;

        if (_closedSoundCoroutine != null)
        {
            StopCoroutine(_closedSoundCoroutine);
            _closedSoundCoroutine = null;
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        if (audioSource != null && doorOpenSound != null)
        {
            audioSource.PlayOneShot(doorOpenSound);
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        StartCoroutine(DestroyAfterOpening());
    }

    private void PlayClosedDoorSound()
    {
        if (audioSource == null || doorClosedSound == null)
            return;

        if (Time.time - _lastClosedSoundTime < closedSoundCooldown)
            return;

        _lastClosedSoundTime = Time.time;

        if (_closedSoundCoroutine != null)
        {
            StopCoroutine(_closedSoundCoroutine);
        }

        _closedSoundCoroutine = StartCoroutine(ClosedDoorSoundCoroutine());
    }

    private IEnumerator ClosedDoorSoundCoroutine()
    {
        audioSource.clip = doorClosedSound;
        audioSource.loop = false;
        audioSource.Play();

        yield return new WaitForSeconds(doorClosedSoundDuration);

        if (audioSource.clip == doorClosedSound)
        {
            audioSource.Stop();
        }
    }

    private IEnumerator DestroyAfterOpening()
    {
        yield return new WaitForSeconds(doorOpenDuration);

        Destroy(gameObject);
    }
}