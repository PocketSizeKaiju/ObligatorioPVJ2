using UnityEngine;

public class PassiveEnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachDistance = 0.1f;

    private int _currentWaypointIndex;

    private void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        Transform target = waypoints[_currentWaypointIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) <= reachDistance)
        {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= waypoints.Length)
            {
                enabled = false;
            }
        }
    }
}