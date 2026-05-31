using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public GameObject _light;
    public Vector2 LastNonZeroDirection => _lastNonZeroDirection;

    private float Speed => Settings.Instance.PlayerSpeed;

    private Vector2 _lastNonZeroDirection;
    private InteractableNpc _nearbyNpc;
    private Rigidbody2D _rigidBody;

    private Vector2 _movement;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        fieldOfView.SetAimDirection(_lastNonZeroDirection);
    }

    private void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        UpdateKeyboardInput();
        RotateLight();
        HandleInteraction();
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

    private void HandleInteraction()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (_nearbyNpc != null)
            {
                _nearbyNpc.Interact();
            }
        }
    }

    private float _SanityFlag = 0f;
    private float _SanityPivot = 1f; //No es pivot pero no me sale la palabra
    private void RotateLight()
    {
        float anglePivot = 90f; //No es pivot pero no me sale la palabra
        if (_light)
        {
            if (_lastNonZeroDirection == Vector2.zero)
                return;

            float _sanityWiggle = CalculateSanity();
            float angle = Mathf.Atan2(_lastNonZeroDirection.y, _lastNonZeroDirection.x) * Mathf.Rad2Deg;

            if (_SanityFlag <= 0) _SanityPivot = UnityEngine.Random.Range(-1, 2);

            anglePivot += _sanityWiggle * _SanityPivot;
            _light.transform.rotation = Quaternion.Euler(0, 0, angle + anglePivot);

            Renderer lightRenderer = _light.GetComponentInChildren<Renderer>();
            if (lightRenderer != null && lightRenderer.enabled)
            {
                fieldOfView.SetStartingAngle(angle + anglePivot);
                fieldOfView.SetViewDistance(10f);
            }
            else
            {
                fieldOfView.SetAimDirection(_lastNonZeroDirection);
                fieldOfView.SetViewDistance(5f);
            }

            if (_SanityFlag > 0) _SanityFlag -= 1;
            else _SanityFlag = 50;
        }
    }

    public float CalculateSanity()
    {
        int currentLife = Settings.Instance.PlayerLife;
        int maxLife = Settings.Instance.PlayerMaxLife;

        float lifePercent = (float)currentLife / maxLife;
        float insanity = 1f - lifePercent;
        float maxAngle = 180f;

        return insanity * maxAngle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        InteractableNpc npc = other.GetComponent<InteractableNpc>();

        if (npc != null)
        {
            _nearbyNpc = npc;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        InteractableNpc npc = other.GetComponent<InteractableNpc>();

        if (npc != null && npc == _nearbyNpc)
        {
            _nearbyNpc = null;
        }
    }
}
