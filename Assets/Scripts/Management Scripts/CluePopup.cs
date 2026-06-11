using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CluePopup : MonoBehaviour
{
    public GameObject _gameObject;

    private bool isActive = false;
    private bool showOnce = false;

    void Update()
    {
        if ((isActive || showOnce) && Keyboard.current.eKey.wasPressedThisFrame)
        {
            _gameObject.SetActive(!_gameObject.activeSelf);
            Time.timeScale = _gameObject.activeSelf ? 0f : 1f;
            showOnce = false;
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
        _gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
