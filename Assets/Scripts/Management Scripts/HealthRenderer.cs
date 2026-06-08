using UnityEngine;
using TMPro;

public class HealthRenderer : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text foundText;
    void Update()
    {
        healthText.text = $"{Settings.Instance.PlayerLife}/{Settings.Instance.PlayerMaxLife}";
        foundText.text = $"{Settings.Instance.SurvivoursLeft}/{Settings.Instance.survivoursOnScenes} Encontrados";
    }
}
