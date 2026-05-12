using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float Speed => Settings.Instance.PlayerSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKeyboardInput();
        UpdateMouseInput();
    }

    private void UpdateMouseInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("click");
        }
    }

    private void UpdateKeyboardInput()
    {
        Vector3 pos = transform.position;
        
        Vector3 direction = Vector2.zero;

        if (Keyboard.current.leftArrowKey.IsPressed())
        {
            direction.x += -1;
        }
        if (Keyboard.current.rightArrowKey.IsPressed())
        {
            direction.x += 1;
        }
        if (Keyboard.current.downArrowKey.IsPressed())
        {
           direction.y += -1;
        }
        if (Keyboard.current.upArrowKey.IsPressed())
        {
            direction.y += 1;
        }

        Vector3 velocity = direction.normalized * Speed;
        transform.position += velocity * Time.deltaTime;
    }
}
