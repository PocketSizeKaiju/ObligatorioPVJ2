using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
