using Unity.VisualScripting;
using UnityEngine;

public class BadPickup : MonoBehaviour
{
    public float Life = 5;
    private bool Enlighted = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Luz")
        {
            if (Life > 0) Enlighted = true;
            else DeathAction();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Luz")
        {
            if (Life > 0) Enlighted = false;
        }
    }

    private void Update()
    {
        if (Enlighted && Life > 0) Life -= Time.deltaTime;
        else if (Life <= 0) DeathAction();
    }

    private void DeathAction()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
