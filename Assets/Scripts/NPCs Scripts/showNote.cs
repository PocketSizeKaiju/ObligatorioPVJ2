using UnityEngine;
using TMPro;

public class showNote : MonoBehaviour
{
    public TMP_Text noteText; 
    public GameObject noteManager; 
    public string text; 
    
    private bool pickedUp; 

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.name == "Player") {
            noteText.text = text;
            noteManager.GetComponent<CluePopup>().activateNote();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name  == "Player"){
            Debug.Log("ext: "+other.name);
            noteManager.GetComponent<CluePopup>().deactivateNote();
        }
    }
}
