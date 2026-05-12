using Unity.VisualScripting;
using UnityEngine;

public class BadPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision with " + other.name);
        if (other.name == "Luz")
        {
            gameObject.GetComponent<Renderer> ().material.color = Color.red;
        }
        else
        {
            Settings.Instance.PlayerLife -= 1;
            Debug.Log("Player life " + Settings.Instance.PlayerLife);
            Destroy(gameObject);
        }
    }
}
