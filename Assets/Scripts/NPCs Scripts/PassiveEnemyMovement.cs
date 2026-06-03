using System.Collections;
using UnityEngine;

public class PassiveEnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachDistance = 0.1f;
    [SerializeField] private float waitTimeAtWaypoint = 1.5f;

    private int _currentWaypointIndex;
    private bool _isMoving;
    private bool _isWaiting;

    private void Update()
    {
        if (!_isMoving || _isWaiting)
        {
            return;
        }

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
            StartCoroutine(GoToNextWaypointAfterDelay());
        }
    }

    public void StartMoving()
    {
        _isMoving = true;
    }

    private IEnumerator GoToNextWaypointAfterDelay()
    {
        _isWaiting = true;

        yield return new WaitForSeconds(waitTimeAtWaypoint);

        _currentWaypointIndex++;

        if (_currentWaypointIndex >= waypoints.Length)
        {
            _isMoving = false;
            enabled = false;
            yield break;
        }

        _isWaiting = false;
    }
}