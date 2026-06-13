using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string currentSceneName = "SandBox";

    private bool _isGameOver;

    private void Start()
    {
        GameState.IsGameOver = false;
        GameState.IsPaused = false;

        Settings.Instance.PlayerLife = Settings.Instance.PlayerMaxLife;

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        Debug.Log("GameOverManager Update funcionando");

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
            Debug.Log("Game Over detectado");
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
        GameState.IsGameOver = false;
        GameState.IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToMenu()
    {
        GameState.IsGameOver = false;
        GameState.IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}