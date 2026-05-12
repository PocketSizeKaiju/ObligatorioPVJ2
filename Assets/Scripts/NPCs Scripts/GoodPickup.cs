using Unity.VisualScripting;
using UnityEngine;

public class GoodPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Luz")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            Debug.Log("collision with " + other.name);
            Settings.Instance.PlayerLife += 1;
            Debug.Log("Player life " + Settings.Instance.PlayerLife);
            Destroy(gameObject);
        }
    }
}
