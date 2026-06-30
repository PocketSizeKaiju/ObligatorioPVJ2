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

    [Header("Sonido de ataque")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private float attackSoundDuration = 1f;

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;

    private Coroutine attackSoundCoroutine;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
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

            PlayAttackSound();

            if (bloodPrefab != null)
            {
                GameObject blood = Instantiate(
                    bloodPrefab,
                    player.position,
                    Quaternion.identity
                );

                Destroy(blood, 3f);
            }
        }

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }

    private void PlayAttackSound()
    {
        if (audioSource == null || attackSound == null)
            return;

        if (attackSoundCoroutine != null)
        {
            StopCoroutine(attackSoundCoroutine);
        }

        attackSoundCoroutine = StartCoroutine(AttackSoundCoroutine());
    }

    private IEnumerator AttackSoundCoroutine()
    {
        audioSource.clip = attackSound;
        audioSource.loop = false;
        audioSource.Play();

        yield return new WaitForSeconds(attackSoundDuration);

        if (audioSource.clip == attackSound)
        {
            audioSource.Stop();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}