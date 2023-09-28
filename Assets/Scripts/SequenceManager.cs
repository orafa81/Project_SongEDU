using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SequenceManager : MonoBehaviour
{
    // Variáveis para configurar a sequência de notas
    public NoteKey[] noteConfigs;
    public float timeBetweenNotes = 1f;

    private int currentNoteIndex = 0;
    private bool isPlaying = false;
    private bool shouldShowInfoPanel = false;
    private int incorrectAttempts = 0;
    private int maxIncorrectAttempts = 3;

    public GameObject infoPanel; // Adicione uma referência ao painel de informações no Inspector

    public delegate void IncorrectAttemptsExceededAction();
    public event IncorrectAttemptsExceededAction OnIncorrectAttemptsExceeded;

    private void Start()
    {
        // Certifique-se de que o painel de informações esteja desativado no início
        infoPanel.SetActive(false);
    }

    private void Update()
    {
        if (shouldShowInfoPanel)
        {
            infoPanel.SetActive(true);
            shouldShowInfoPanel = false;
        }
    }

    public void StartNoteSequence()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayNoteSequence());
        }
    }

    private IEnumerator PlayNoteSequence()
    {
        isPlaying = true;

        while (currentNoteIndex < noteConfigs.Length)
        {
            PlayNoteSound(currentNoteIndex);
            yield return new WaitForSeconds(timeBetweenNotes);
            currentNoteIndex++;
        }

        currentNoteIndex = 0;
        isPlaying = false;
    }

    private void PlayNoteSound(int index)
    {
        // Adicione aqui a lógica para tocar o som da nota com base na configuração da nota.
        // Você pode usar o AudioSource ou outro método para reproduzir os sons das notas.
    }

    private void RestartSequence()
    {
        currentNoteIndex = 0;
        isPlaying = false;
        incorrectAttempts = 0;

        if (incorrectAttempts >= maxIncorrectAttempts)
        {
            shouldShowInfoPanel = true;
            infoPanel.SetActive(true);
            StartRepeatingAfterDelay(3f);
        }
    }

    private void StartRepeatingAfterDelay(float delay)
    {
        StartCoroutine(StartRepeatingCoroutine(delay));
    }

    private IEnumerator StartRepeatingCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartNoteSequence();
    }

    public bool CheckPlayerInput(int playerNoteIndex)
    {
        if (!isPlaying)
        {
            Debug.Log("O jogador tentou tocar mais notas do que a sequência alvo.");
            return false;
        }

        if (noteConfigs[currentNoteIndex].noteIndex != playerNoteIndex)
        {
            Debug.Log("Erro! A nota tocada está incorreta.");

            incorrectAttempts++;

            if (incorrectAttempts >= maxIncorrectAttempts)
            {
                Debug.Log("Você errou 3 vezes. Reiniciando a sequência.");
                RestartSequence();
                if (OnIncorrectAttemptsExceeded != null)
                {
                    OnIncorrectAttemptsExceeded();
                }
            }

            return false;
        }

        currentNoteIndex++;

        if (!isPlaying)
        {
            Debug.Log("Sequência repetida com sucesso!");
            incorrectAttempts = 0;
        }

        return true;
    }
}

