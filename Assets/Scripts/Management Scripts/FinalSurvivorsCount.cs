using UnityEngine;
using TMPro;

public class FinalSurvivorsCount : MonoBehaviour
{
    public TMP_Text scoreText;
    void Start()
    {
        scoreText.text = $"Rescataste {Settings.Instance.SurvivoursLeft}/{Settings.Instance.survivoursOnScenes}";
    }
}
