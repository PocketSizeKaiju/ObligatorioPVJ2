using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject _gameObject;

    void Start()
    {
        _gameObject.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            _gameObject.SetActive(!_gameObject.activeSelf);

            GameState.IsPaused = _gameObject.activeSelf;
            Time.timeScale = GameState.IsPaused ? 0f : 1f;
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame && _gameObject.activeSelf)
        {
            GameState.IsPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }
}
