using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject _light;

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
        RotateLight();
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

    private void RotateLight()
    {
        if (_light)
        {
            if (_lastNonZeroDirection == Vector2.zero)
                return;

            float angle = Mathf.Atan2(_lastNonZeroDirection.y, _lastNonZeroDirection.x) * Mathf.Rad2Deg;

            _light.transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        }
    }
}
