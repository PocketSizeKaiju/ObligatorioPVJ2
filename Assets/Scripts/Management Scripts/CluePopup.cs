using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CluePopup : MonoBehaviour
{
    public GameObject _gameObject;

    private bool isActive = false;

    void Update()
    {
        if (isActive && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log(_gameObject.activeSelf);
            _gameObject.SetActive(!_gameObject.activeSelf);
            Debug.Log(_gameObject.activeSelf);
            Time.timeScale = _gameObject.activeSelf ? 0f : 1f;
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
        isActive = true;
        _gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
