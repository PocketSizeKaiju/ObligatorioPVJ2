using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CluePopup : MonoBehaviour
{
    public GameObject _gameObject;

    private bool isActive = false;

    void Start()
    {
        _gameObject.SetActive(false);
    }

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
    public void activateNote(){
        Debug.Log("activado" + isActive);
        isActive = true;
    }

    public void deactivateNote(){
        Debug.Log("desactivado" + isActive);
        isActive = false;
    }
}
