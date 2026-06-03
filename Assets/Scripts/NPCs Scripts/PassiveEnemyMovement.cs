using UnityEngine;

public class PassiveEnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachDistance = 0.1f;
    [SerializeField] private float maxDistanceFromPlayer = 3f;

    private int _currentWaypointIndex;
    private bool _isMoving;

    private void Update()
    {
        if (!_isMoving)
        {
            return;
        }

        if (player == null || waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > maxDistanceFromPlayer)
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
                _isMoving = false;
                enabled = false;
            }
        }
    }

    public void StartMoving()
    {
        _isMoving = true;
    }
}