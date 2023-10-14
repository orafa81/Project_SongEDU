using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SequenceManager : MonoBehaviour
{
    public List<NoteSequence> sequences; // Lista de sequências
    private int currentSequenceIndex = 0; // Índice da sequência atual
    private int currentNoteIndex = 0;
    private bool isPlaying = false;
    private int incorrectAttempts = 0;

    public GameObject infoPanel;
    private bool showInfoPanel = false;

    private NoteConfig[] noteConfigs;
    private Coroutine sequenceCoroutine;

    public void StartNoteSequence()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            currentNoteIndex = 0;
            incorrectAttempts = 0;

            NoteSequence currentSequence = sequences[currentSequenceIndex];

            if (currentSequence.notes.Length == 0)
            {
                Debug.Log("A sequência está vazia. Finalizando o jogo ou outra ação apropriada.");
                return;
            }

            noteConfigs = new NoteConfig[currentSequence.notes.Length];

            for (int i = 0; i < currentSequence.notes.Length; i++)
            {
                noteConfigs[i] = GetNoteConfig(currentSequence.notes[i]);
            }

            if (sequenceCoroutine != null)
            {
                StopCoroutine(sequenceCoroutine);
            }
            sequenceCoroutine = StartCoroutine(PlayNoteSequence());
        }
    }

    private IEnumerator PlayNoteSequence()
    {
        while (currentNoteIndex < noteConfigs.Length)
        {
            NoteConfig currentNote = noteConfigs[currentNoteIndex];
            PlaySound(currentNote.sound);
            yield return new WaitForSeconds(currentNote.duration);
            currentNoteIndex++;
        }

        if (currentNoteIndex == noteConfigs.Length)
        {
            isPlaying = false;
        }
    }

    private NoteConfig GetNoteConfig(int noteIndex)
    {
        return noteConfigs[noteIndex];
    }

    private void PlaySound(AudioClip sound)
    {
        // Implemente a lógica para tocar o som da nota aqui
        // Isso pode envolver a reprodução de um som ou outra ação relacionada ao som da nota
    }

    private void RestartSequence()
    {
        currentNoteIndex = 0;
        isPlaying = false;
        incorrectAttempts = 0;

        if (incorrectAttempts >= maxIncorrectAttempts)
        {
            shouldShowInfoPanel = true;
        }

        StartCoroutine(ShowInfoPanelAndRestart());
    }

    private IEnumerator ShowInfoPanelAndRestart()
    {
        if (showInfoPanel)
        {
            infoPanel.SetActive(true);
            float delayTime = 5.0f;
            yield return new WaitForSeconds(delayTime);
            infoPanel.SetActive(false);

            AdvanceToNextSequence(); // Avança para a próxima sequência
        }
    }

    private void AdvanceToNextSequence()
    {
        currentSequenceIndex++;

        if (currentSequenceIndex >= sequences.Count)
        {
            Debug.Log("Você completou todas as sequências disponíveis. Pode adicionar mais sequências se desejar.");
            // Lógica de fim de jogo aqui, por exemplo, mostrar tela de vitória ou encerrar o jogo.
        }
        else
        {
            StartNoteSequence(); // Inicie a próxima sequência
        }
    }
}
