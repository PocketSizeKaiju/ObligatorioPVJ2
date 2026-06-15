using UnityEngine;
using System.Collections;

public class RandomPatrol : MonoBehaviour
{

    [Header("RandomPatrol parameters")]
    public float speed;
    public float minPatrolTime;
    public float maxPatrolTime;
    public float minWaitTime;
    public float maxWaitTime;
    [Header("Chase parameters")]
    public float chaseRange = 3f;
    private Transform target;
    private bool isChasing = false;

    [Header("Alert")]
    [SerializeField] private GameObject alertIcon;

    private Rigidbody2D rb;

    Animator animator;
    Vector2 direction;
    private Coroutine patrolCoroutine;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Patrol());
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        patrolCoroutine = StartCoroutine(Patrol());
    }
    void Update()
    {
        if (target == null) return;

        float distanceToTarget = Vector2.Distance(target.position, transform.position);

        if (distanceToTarget < chaseRange)
        {
            if (!isChasing)
            {
                isChasing = true;
                if (alertIcon != null)
        alertIcon.SetActive(true);
                if (patrolCoroutine != null) StopCoroutine(patrolCoroutine); 
            }

            Vector2 directionToTarget = target.position - transform.position;
            direction = directionToTarget.normalized;
            UpdateAnimations();
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                if (alertIcon != null)
        alertIcon.SetActive(false);
                patrolCoroutine = StartCoroutine(Patrol());
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction.normalized * speed;
    }
    IEnumerator Patrol()
    {
        direction = RandomDirection();
        UpdateAnimations();
        yield return new WaitForSeconds(Random.Range(minPatrolTime, maxPatrolTime));
        direction = Vector2.zero;
        UpdateAnimations();
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        patrolCoroutine = StartCoroutine(Patrol());    
    }

    private Vector2 RandomDirection()
    {
        int random = Random.Range(0, 8);

        return random switch
        {
            0 => Vector2.up,
            1 => Vector2.down,
            2 => Vector2.left,
            3 => Vector2.right,
            4 => new Vector2(1, 1),
            5 => new Vector2(-1, 1),
            6 => new Vector2(1, -1),
            _ => new Vector2(-1, -1),
        };
    }

    private void UpdateAnimations()
    {
        if(direction.magnitude != 0)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }
        rb.linearVelocity = direction.normalized * speed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
