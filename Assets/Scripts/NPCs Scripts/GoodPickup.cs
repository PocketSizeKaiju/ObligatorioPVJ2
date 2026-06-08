using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class GoodPickup : MonoBehaviour
{
    public float Life = 5;
    private bool Enlighted = false;
    public bool IsSurvivour = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Luz")
        {
            if (Life > 0) Enlighted = true;
            else DeathAction();
        }
        else if(other.name == "Player")
        {
            Settings.Instance.PlayerLife += 1;
            if (IsSurvivour) Settings.Instance.SurvivoursLeft += 1;
            Destroy(gameObject);
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
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
