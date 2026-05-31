using Unity.VisualScripting;
using UnityEngine;

public class FallingScript : MonoBehaviour
{

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 direction = Vector2.zero;
        direction.y += -1;
        Vector3 velocity = direction.normalized * 1;
        transform.position += velocity * Time.deltaTime;

        if(transform.position.y < -7.48) Destroy(gameObject);
    }
}
