using UnityEngine;

public class InteractableNpc : MonoBehaviour
{
    [SerializeField] private string dialogueText = "Diálogo ejemplo";

    private DialogueShower _dialogueShower;

    private void Awake()
    {
        _dialogueShower = FindFirstObjectByType<DialogueShower>();
    }

    public void Interact()
    {
        if (_dialogueShower == null)
        {
            return;
        }

        _dialogueShower.ShowDialogue(dialogueText);
    }
}