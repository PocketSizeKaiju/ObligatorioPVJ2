using UnityEngine;

public class BreathInsanity : MonoBehaviour
{
    [SerializeField] public GameObject UI;
    private Color tempcolor;

    void Update()
    {
        int currentLife = Settings.Instance.PlayerLife;
        int maxLife = Settings.Instance.PlayerMaxLife;

        float lifePercent = (float)currentLife / maxLife;

        float speed = Mathf.Lerp(
                    1,
                    0,
                    lifePercent
                );

        float breath = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;

        float intensity = 1f - lifePercent;

        tempcolor = GetComponent<MeshRenderer>().material.color;
        tempcolor.a = breath * intensity;
        GetComponent<MeshRenderer>().material.color = tempcolor;
    }
}
