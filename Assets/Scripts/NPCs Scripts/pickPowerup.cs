using UnityEngine;

public class pickPowerup : MonoBehaviour
{
    private bool pickedUp;
    private bool startTimer;
    private double delta;

    public int duration;
    public FieldOfView FieldOfView;
    public GameObject Luz;

    private void OnTriggerEnter2D(Collider2D other)
    {
        pickedUp = other.name == "Player";

        GetComponent<Renderer>().enabled = false;
    }

    private void LateUpdate()
    {
        if (pickedUp)
        {
            delta += Time.deltaTime;
            FieldOfView.SetViewDistance(10f);

            if (delta > duration)
            {
                FieldOfView.SetViewDistance(5f);
                Destroy(gameObject);
            }
        }
        else
        {
            delta = 0;
        }
    }
}
