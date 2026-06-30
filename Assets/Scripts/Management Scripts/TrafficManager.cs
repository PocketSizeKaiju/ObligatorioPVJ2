using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] private GameObject _goodPrefab;
    [SerializeField] private GameObject _badPrefab;

    private double delta;


    void Start()
    {
        /* for (int i = 0; i < 10; i++)
        {
            GameObject newCoin = Instantiate(_goodPrefab);
            newCoin.transform.position = new Vector2(
        x: Random.Range(-8, 8),
        y: Random.Range(6, 6));
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject newCoin = Instantiate(_badPrefab);
            newCoin.transform.position = new Vector2(
        x: Random.Range(-8, 8),
        y: Random.Range(6, 6));
        } */
    }

    private void Update()
    {
        delta += Time.deltaTime;
        GameObject newSpawn;
        if (delta > 1)
        {
            if (Random.Range(-4, 8) > 0)
            {
                newSpawn = Instantiate(_goodPrefab);
            }
            else
            {
                newSpawn = Instantiate(_badPrefab);
            }
            newSpawn.transform.position = new Vector2(
                x: Random.Range(-8, 8),
                y: Random.Range(6, 6));
            delta = 0;
        }
    }
}
