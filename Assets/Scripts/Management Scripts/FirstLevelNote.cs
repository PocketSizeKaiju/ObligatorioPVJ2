using UnityEngine;
using TMPro;

public class FirstLevelNote : MonoBehaviour
{
    public TMP_Text noteText;
    public GameObject noteManager;
    [TextArea(5, 20)]
    public string text;
    public bool showNoteMsg = true;
    public int witnessesInLevel = 1;

    void Start()
    {
        if (showNoteMsg)
        {
            noteText.text = text;
            noteText.fontSize = 10;
            noteManager.GetComponent<CluePopup>().ShowNote();
            showNoteMsg = false;
        }
        else
        {
            noteManager.GetComponent<CluePopup>().HideNote();
        }
        Settings.Instance.survivoursOnScenes += witnessesInLevel;
    }
}
