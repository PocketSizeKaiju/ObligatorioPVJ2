using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private string menuSceneName = "InitialScene";
    [SerializeField] private string currentSceneName = "SandBox";

    [Header("Sonido de Game Over")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private float gameOverSoundDuration = 3f;

    private bool _isGameOver;
    private Coroutine _gameOverSoundCoroutine;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        GameState.IsGameOver = false;
        GameState.IsPaused = false;

        Settings.Instance.PlayerLife = Settings.Instance.PlayerMaxLife;

        if (gameOverPanel) gameOverPanel?.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (_isGameOver)
        {
            return;
        }

        Debug.Log("_isGameOver" + _isGameOver);

        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            Settings.Instance.PlayerLife = 0;
        }

        if (Settings.Instance.PlayerLife <= 0)
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        _isGameOver = true;
        GameState.IsGameOver = true;
        Debug.Log("GameState.IsGameOver" + GameState.IsGameOver);

        gameOverPanel.SetActive(true);

        PlayGameOverSound();

        Time.timeScale = 0f;
        Debug.Log("gameOverPanel" + gameOverPanel);
    }

    private void PlayGameOverSound()
    {
        if (audioSource == null || gameOverSound == null)
            return;

        if (_gameOverSoundCoroutine != null)
        {
            StopCoroutine(_gameOverSoundCoroutine);
        }

        _gameOverSoundCoroutine = StartCoroutine(GameOverSoundCoroutine());
    }

    private IEnumerator GameOverSoundCoroutine()
    {
        audioSource.clip = gameOverSound;
        audioSource.loop = false;
        audioSource.Play();

        yield return new WaitForSecondsRealtime(gameOverSoundDuration);

        if (audioSource.clip == gameOverSound)
        {
            audioSource.Stop();
        }
    }

    public void Retry()
    {
        Debug.Log("clicked Retry");
        GameState.IsGameOver = false;
        GameState.IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToMenu()
    {
        Debug.Log("clicked GoToMenu");
        Debug.Log(menuSceneName);
        GameState.IsGameOver = false;
        GameState.IsPaused = false;
        Time.timeScale = 1f;
        Settings.Instance.survivoursOnScenes = 0;
        Settings.Instance.SurvivoursLeft = 0;
        SceneManager.LoadScene(menuSceneName);
    }
}