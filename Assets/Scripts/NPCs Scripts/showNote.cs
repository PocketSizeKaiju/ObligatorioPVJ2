using UnityEngine;
using TMPro;

public class showNote : MonoBehaviour
{
    public TMP_Text noteText;
    public GameObject noteManager;
    [TextArea(5, 20)]
    public string text;

    private bool pickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            noteText.text = text;
            noteText.fontSize = 23;

            noteManager.GetComponent<CluePopup>().activateNote();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            noteManager.GetComponent<CluePopup>().deactivateNote();
        }
    }
}
