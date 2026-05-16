using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 LastNonZeroDirection => _lastNonZeroDirection;

    private float Speed => Settings.Instance.PlayerSpeed;

    /* // #region  Player bounds
    private float PlayerBoundsYMin => Settings.Instance.PlayerBoundsYMin;
    private float PlayerBoundsYMax => Settings.Instance.PlayerBoundsYMax;
    private float PlayerBoundsXMin => Settings.Instance.PlayerBoundsXMin;
    private float PlayerBoundsXMax => Settings.Instance.PlayerBoundsXMax;
    // #endregion */

    private Vector2 _lastNonZeroDirection;

    void Update()
    {
        UpdateKeyboardInput();
    }

    private void UpdateKeyboardInput()
    {
        Vector2 direction = new Vector2(
            ((Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) ? 1 : 0) -
            ((Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) ? 1 : 0),
            ((Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed) ? 1 : 0) -
            ((Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed) ? 1 : 0)
        );

        Vector3 velocity = (Vector3)(direction.normalized * Speed);
        Vector3 pos = transform.position;

        pos += velocity * Time.deltaTime;
        /* pos.y = Mathf.Clamp(pos.y, PlayerBoundsYMin, PlayerBoundsYMax);
        pos.x = Mathf.Clamp(pos.x, PlayerBoundsXMin, PlayerBoundsXMax); */

        transform.position = pos;

        if (direction != Vector2.zero)
        {
            _lastNonZeroDirection = direction;
        }
    }
}
