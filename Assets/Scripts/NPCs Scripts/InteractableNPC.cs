using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] private string firstDialogueText = "Sígueme, conozco la salida.";
    [SerializeField] private string movingDialogueText = "No te quedes atrás...";
    [SerializeField] private string finalDialogueText = "Llegamos... demasiado tarde para ti.";
    [SerializeField] private GameObject activeEnemyPrefab;

    private DialogueShower _dialogueShower;
    private PassiveEnemyMovement _movement;
    private bool _hasStartedMoving;

    private void Awake()
    {
        _dialogueShower = FindFirstObjectByType<DialogueShower>();
        _movement = GetComponent<PassiveEnemyMovement>();
    }

    public void Interact()
    {
        if (_movement != null && _movement.HasReachedFinalWaypoint)
        {
            ShowDialogue(finalDialogueText);
            TransformIntoActiveEnemy();
            return;
        }

        if (!_hasStartedMoving)
        {
            ShowDialogue(firstDialogueText);
            _movement?.StartMoving();
            _hasStartedMoving = true;
            return;
        }

        ShowDialogue(movingDialogueText);
    }

    private void ShowDialogue(string text)
    {
        if (_dialogueShower != null)
        {
            _dialogueShower.ShowDialogue(text);
        }
    }

    private void TransformIntoActiveEnemy()
    {
        if (activeEnemyPrefab != null)
        {
            Instantiate(activeEnemyPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}