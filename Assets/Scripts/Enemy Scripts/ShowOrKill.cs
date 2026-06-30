using UnityEngine;
using Unity.VisualScripting;

public class ShowOrKill : MonoBehaviour
{
    public float Life = 5;
    public bool isEnemy = false;

    private bool Enlighted = false;
    private DialogueShower _dialogueShower;
    private bool _revealed = false;

    private void Awake()
    {
        _dialogueShower = FindFirstObjectByType<DialogueShower>();
    }

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
        if (isEnemy)
        {
            string[] survivorLines =
            {
                "¡La luz! ¡¡Quemaa!!",
                "¡¡AAARRRGH!!",
                "¡¡NOOOO!!",
                "¡¡DETÉN ESTO!!",
                "¡¿Qué me estás haciendo?!",
                "¡No! ¡Apaga esa luz!",
                "¡Te arrancaré los ojos!",
                "¡Maldito humano!",
                "¡No puedes esconderte!",
                "¡La luz no!",
                "¡Te encontraré!",
                "Ayúdame... por favor..."
            };

            _dialogueShower.ShowDialogue(survivorLines[Random.Range(0, survivorLines.Length)]);
            Destroy(gameObject);
        }
        else
        {
            if (!_revealed)
            {
                string[] survivorLines =
                {
                "Gracias... sigo siendo humano.",
                "¿Ya está? ¿Pasé la prueba?",
                "Pensé que era mi fin.",
                "Gracias por encontrarme.",
                "Ten cuidado, hay más ahí fuera.",
                "¿Podrías apuntar a otro lado? Me estás dejando ciego.",
                "Bueno, al menos no exploté.",
                "¡Genial! Otro examen médico gratuito.",
                "¿Ahora me das una medalla?"
            };

                gameObject.GetComponent<Renderer>().material.color = Color.green;
                _dialogueShower.ShowDialogue(survivorLines[Random.Range(0, survivorLines.Length)]);
                _revealed = true;
            }
        }
    }
}
