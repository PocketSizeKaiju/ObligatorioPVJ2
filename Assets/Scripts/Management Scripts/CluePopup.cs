using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class CluePopup : MonoBehaviour
{
    public GameObject _gameObject;

    [Header("Sonido al cerrar nota")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip closeNoteSound;
    [SerializeField] private float closeNoteSoundDuration = 1.5f;

    private bool isActive = false;
    private bool showOnce = false;

    private Coroutine closeSoundCoroutine;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if ((isActive || showOnce) && Keyboard.current.eKey.wasPressedThisFrame)
        {
            bool wasOpen = _gameObject.activeSelf;

            _gameObject.SetActive(!_gameObject.activeSelf);

            bool isNowOpen = _gameObject.activeSelf;

            Time.timeScale = isNowOpen ? 0f : 1f;
            showOnce = false;

            if (wasOpen && !isNowOpen)
            {
                PlayCloseNoteSound();
            }
        }
    }

    public void activateNote()
    {
        isActive = true;
        Debug.Log("activado" + isActive);
    }

    public void deactivateNote()
    {
        isActive = false;
        Debug.Log("desactivado" + isActive);
    }

    public void ShowNote()
    {
        showOnce = true;
        _gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideNote()
    {
        if (_gameObject.activeSelf)
        {
            PlayCloseNoteSound();
        }

        _gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private void PlayCloseNoteSound()
    {
        if (audioSource == null || closeNoteSound == null)
            return;

        if (closeSoundCoroutine != null)
        {
            StopCoroutine(closeSoundCoroutine);
        }

        closeSoundCoroutine = StartCoroutine(PlayCloseNoteSoundCoroutine());
    }

    private IEnumerator PlayCloseNoteSoundCoroutine()
    {
        audioSource.clip = closeNoteSound;
        audioSource.Play();

        yield return new WaitForSecondsRealtime(closeNoteSoundDuration);

        audioSource.Stop();
    }
}