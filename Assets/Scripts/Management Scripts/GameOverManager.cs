using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private string menuSceneName = "InitialScene";
    [SerializeField] private string currentSceneName = "SandBox";

    private bool _isGameOver;

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

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
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