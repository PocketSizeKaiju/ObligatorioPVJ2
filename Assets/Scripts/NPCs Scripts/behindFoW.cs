using UnityEngine;

public class behindFoW : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "FieldOfView")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "FieldOfView")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
