using UnityEngine;

public class pickPowerup : MonoBehaviour
{
    private bool pickedUp;
    private bool startTimer;
    private double delta;
    private Vector3 scale;
    private Vector3 originalScale;

    public int duration;
    public FieldOfView FieldOfView;
    public bool strengthPowerUp;
    public GameObject Luz;
    public float objectSize = 3.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        pickedUp = other.name == "Player";
        scale = Luz.transform.localScale;
        originalScale = Luz.transform.localScale;

        GetComponent<Renderer>().enabled = false;
    }

    private void LateUpdate()
    {
        if (pickedUp)
        {
            if (strengthPowerUp)
            {
                delta += Time.deltaTime;

                scale = Luz.transform.localScale;
                scale.x = objectSize;
                scale.y = objectSize;
                Luz.transform.localScale = scale;

                if (delta > duration)
                {
                    scale = transform.localScale;
                    scale = originalScale;
                    Luz.transform.localScale = scale;
                    Destroy(gameObject);
                }

            }
            else
            {
                delta += Time.deltaTime;
                FieldOfView.SetViewDistance(10f);

                if (delta > duration)
                {
                    FieldOfView.SetViewDistance(5f);
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            delta = 0;
        }

    }
}
