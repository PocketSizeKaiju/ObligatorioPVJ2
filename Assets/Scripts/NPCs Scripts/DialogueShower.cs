using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float visibleTime = 3f;

    private Coroutine _hideCoroutine;

    public void ShowDialogue(string text)
    {
        dialogueText.text = text;
        dialogueText.enabled = true;

        if (_hideCoroutine != null)
        {
            StopCoroutine(_hideCoroutine);
        }

        _hideCoroutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(visibleTime);

        HideDialogue();
    }

    public void HideDialogue()
    {
        dialogueText.text = "";
        dialogueText.enabled = false;
        _hideCoroutine = null;
    }
}