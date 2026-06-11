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
            Debug.Log("Hello");
            Debug.Log(_gameObject.activeSelf);
            _gameObject.SetActive(!_gameObject.activeSelf);
            Debug.Log("After Set active");
            Debug.Log(_gameObject.activeSelf);
            Time.timeScale = _gameObject.activeSelf ? 0f : 1f;
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame && _gameObject.activeSelf)
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1f;
        }
    }
}
