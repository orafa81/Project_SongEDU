using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoteKey : MonoBehaviour
{
    public int noteIndex;
    public float noteDuration = 1.0f;
    public Color pressedColor = Color.green;
    public SequenceManager sequenceManager; // Referência ao SequenceManager

    private KeySoundManager soundManager;
    private bool isPlaying = false;
    private Image image;

    private void Start()
    {
        soundManager = FindObjectOfType<KeySoundManager>();
        image = GetComponent<Image>();
    }

    private void OnMouseDown()
    {
        if (!isPlaying)
        {
            soundManager.PlayNoteSound(noteIndex, noteDuration);
            StartCoroutine(ChangeColorOnPress());
            StartCoroutine(ResetColorAfterDuration());

            // Verifique se a tecla pressionada pelo jogador está correta
            bool playerInputCorrect = sequenceManager.CheckPlayerInput(noteIndex);

            if (playerInputCorrect)
            {
                Debug.Log("Acertou a nota!");
            }
            else
            {
                Debug.Log("Errou a nota!");
            }
        }
    }

    private IEnumerator ChangeColorOnPress()
    {
        isPlaying = true;
        Color originalColor = image.color;
        image.color = pressedColor;
        yield return new WaitForSeconds(noteDuration);
        image.color = originalColor;
        isPlaying = false;
    }

    private IEnumerator ResetColorAfterDuration()
    {
        yield return new WaitForSeconds(noteDuration);
        image.color = image.color;
    }
}

