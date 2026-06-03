using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] private string dialogueText = "Sígueme, conozco la salida.";

    private DialogueShower _dialogueShower;
    private PassiveEnemyMovement _movement;

    private void Awake()
    {
        _dialogueShower = FindFirstObjectByType<DialogueShower>();
        _movement = GetComponent<PassiveEnemyMovement>();
    }

    public void Interact()
    {
        if (_dialogueShower != null)
        {
            _dialogueShower.ShowDialogue(dialogueText);
        }

        if (_movement != null)
        {
            _movement.StartMoving();
        }
    }
}