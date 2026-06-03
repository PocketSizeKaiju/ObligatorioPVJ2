using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] private string firstDialogueText = "Sígueme, conozco la salida.";
    [SerializeField] private string movingDialogueText = "No te quedes atrás...";

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
        if (!_hasStartedMoving)
        {
            ShowDialogue(firstDialogueText);

            if (_movement != null)
            {
                _movement.StartMoving();
            }

            _hasStartedMoving = true;
        }
        else
        {
            ShowDialogue(movingDialogueText);
        }
    }

    private void ShowDialogue(string text)
    {
        if (_dialogueShower != null)
        {
            _dialogueShower.ShowDialogue(text);
        }
    }
}