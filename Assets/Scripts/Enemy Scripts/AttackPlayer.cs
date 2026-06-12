using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackPreparationTime = 0.5f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private int damage = 1;

    [Header("Effects")]
    [SerializeField] private GameObject bloodPrefab;

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player == null || isAttacking)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
        }

        yield return new WaitForSeconds(attackPreparationTime);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            Settings.Instance.PlayerLife -= damage;

            if (Settings.Instance.PlayerLife < 0)
            {
                Settings.Instance.PlayerLife = 0;
            }

            if (bloodPrefab != null)
            {
                
                GameObject blood = Instantiate(
    bloodPrefab,
    player.position,
    Quaternion.identity
);

Destroy(blood, 0.5f);
            }
        }

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}