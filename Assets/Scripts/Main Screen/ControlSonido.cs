using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlSonido : MonoBehaviour
{
    [Header("UI")]
    public Image imagenVolumen;

    [Header("Sprites")]
    public Sprite volumenOn;
    public Sprite volumenOff;

    [Header("Animación")]
    public float tiempoVisible = 1f;
    public float duracionDesvanecimiento = 0.5f;

    private bool estaSilenciado = false;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        AudioListener.volume = 1f;

        imagenVolumen.sprite = volumenOn;
        imagenVolumen.gameObject.SetActive(false);
    }

    public void AlternarSonido()
    {
        estaSilenciado = !estaSilenciado;

        if (estaSilenciado)
        {
            AudioListener.volume = 0f;
            imagenVolumen.sprite = volumenOff;
        }
        else
        {
            AudioListener.volume = 1f;
            imagenVolumen.sprite = volumenOn;
        }

        MostrarYDesvanecer();
    }

    private void MostrarYDesvanecer()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        imagenVolumen.gameObject.SetActive(true);

        fadeCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color color = imagenVolumen.color;

        color.a = 1f;
        imagenVolumen.color = color;

        yield return new WaitForSeconds(tiempoVisible);

        float tiempo = 0f;

        while (tiempo < duracionDesvanecimiento)
        {
            tiempo += Time.deltaTime;

            color.a = Mathf.Lerp(1f, 0f, tiempo / duracionDesvanecimiento);
            imagenVolumen.color = color;

            yield return null;
        }

        color.a = 0f;
        imagenVolumen.color = color;

        imagenVolumen.gameObject.SetActive(false);
    }
}
