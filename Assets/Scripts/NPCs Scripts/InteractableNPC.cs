using UnityEngine;
using System.Collections;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] private string firstDialogueText = "Sígueme, conozco la salida.";
    [SerializeField] private string movingDialogueText = "No te quedes atrás...";
    [SerializeField] private string finalDialogueText = "Llegamos... demasiado tarde para ti.";
    [SerializeField] private GameObject activeEnemyPrefab;

    [SerializeField] private bool isNotEnemy;

    [Header("Sonido de diálogo")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueSound;
    [SerializeField] private float dialogueSoundDuration = 3f;

    private DialogueShower _dialogueShower;
    private PassiveEnemyMovement _movement;
    private bool _hasStartedMoving;

    private Coroutine _dialogueSoundCoroutine;

    private void Awake()
    {
        _dialogueShower = FindFirstObjectByType<DialogueShower>();
        _movement = GetComponent<PassiveEnemyMovement>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Interact()
    {
        if (_movement != null && _movement.HasReachedFinalWaypoint)
        {
            ShowDialogue(finalDialogueText);
            TransformIntoActiveEnemy();
            return;
        }

        if (!_hasStartedMoving)
        {
            ShowDialogue(firstDialogueText);
            _movement?.StartMoving();
            _hasStartedMoving = true;
            return;
        }

        ShowDialogue(movingDialogueText);
    }

    private void ShowDialogue(string text)
    {
        if (_dialogueShower != null)
        {
            _dialogueShower.ShowDialogue(text);
        }
        PlayDialogueSound();
    }
    private void PlayDialogueSound()
    {
        if (audioSource == null || dialogueSound == null)
            return;

        if (_dialogueSoundCoroutine != null)
        {
            StopCoroutine(_dialogueSoundCoroutine);
        }

        _dialogueSoundCoroutine = StartCoroutine(DialogueSoundCoroutine());
    }

    private IEnumerator DialogueSoundCoroutine()
    {
        audioSource.clip = dialogueSound;
        audioSource.loop = true;
        audioSource.Play();

        yield return new WaitForSeconds(dialogueSoundDuration);

        audioSource.Stop();
        audioSource.loop = false;
    }

    private void TransformIntoActiveEnemy()
    {
        if (activeEnemyPrefab != null)
        {
            Instantiate(activeEnemyPrefab, transform.position, transform.rotation);
        }
        else if (isNotEnemy)
        {
            Settings.Instance.SurvivoursLeft += 1;
        }

        Destroy(gameObject);
    }
}