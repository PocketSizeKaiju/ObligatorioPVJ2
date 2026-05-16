using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 LastNonZeroDirection => _lastNonZeroDirection;

    private float Speed => Settings.Instance.PlayerSpeed;

    private Vector2 _lastNonZeroDirection;
    private Rigidbody2D _rigidBody;

    private Vector2 _movement;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateKeyboardInput();
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = _movement.normalized * Speed;
    }

    private void UpdateKeyboardInput()
    {
        _movement = new Vector2(
            ((Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) ? 1 : 0) -
            ((Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) ? 1 : 0),
            ((Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed) ? 1 : 0) -
            ((Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed) ? 1 : 0)
        );

        if (_movement != Vector2.zero)
            _lastNonZeroDirection = _movement;
    }
}
