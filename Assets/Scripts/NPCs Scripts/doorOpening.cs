using UnityEngine;
using UnityEngine.InputSystem;

public class doorOpening : MonoBehaviour
{
    public GameObject doorOpener;

    public bool isOpen;
    public bool playerNearby;

     private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            playerNearby = true;
        }
        else if (other.gameObject == doorOpener)
        {
            isOpen = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player") {
            playerNearby = false;
        }
        else if (other.gameObject == doorOpener)
        {
            isOpen = false;
        }
    }

    public void Update() {
        
            if (isOpen &&
            playerNearby&&
            Keyboard.current.eKey.wasPressedThisFrame) {
                Destroy(gameObject);
            }
    }
}
