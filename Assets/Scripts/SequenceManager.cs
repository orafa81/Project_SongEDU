using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SequenceManager : MonoBehaviour
{
    [System.Serializable]
    public struct NoteConfig
    {
        public NoteKey noteKey;
        public float noteDuration;
        public Color pressedColor;
    }

    public NoteConfig[] noteConfigs;
    public NoteConfig[] noteConfigs2;
    private KeySoundManager soundManager;
    private Coroutine sequenceCoroutine;
    private int currentNoteIndex = 0;
    private int incorrectAttempts = 0;
    private int maxIncorrectAttempts = 3;
    private int rodada = 0;
    private bool isPlaying = false;
    private bool shouldShowInfoPanel = false; // Flag para mostrar o painel de informações

    public GameObject infoPanel; // Adicione uma referência ao painel de informações no Inspector

    public bool IsPlayingSequence { get { return isPlaying; } }
    public bool IsRepeating { get { return currentNoteIndex < noteConfigs.Length; } }

    private void Start()
    {
        soundManager = FindObjectOfType<KeySoundManager>();
    }

    private void Update()
    {
        if (shouldShowInfoPanel)
        {
            infoPanel.SetActive(true);
            shouldShowInfoPanel = false; // Para evitar que o painel seja exibido repetidamente
        }
    }

    public void StartNoteSequence()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            currentNoteIndex = 0;
            incorrectAttempts = 0;
            
            if (sequenceCoroutine != null)
            {
                StopCoroutine(sequenceCoroutine);
            }
            sequenceCoroutine = StartCoroutine(PlayNoteSequence(rodada));
        }
    }

    public bool CheckPlayerInput(int playerNoteIndex)
    {
        if (!IsRepeating)
        {
            Debug.Log("O jogador tentou tocar mais notas do que a sequência alvo.");
            return false;
        }

        if (noteConfigs[currentNoteIndex].noteKey.noteIndex != playerNoteIndex)
        {
            Debug.Log("Erro! A nota tocada está incorreta.");

            incorrectAttempts++;

            if (incorrectAttempts >= maxIncorrectAttempts)
            {
                Debug.Log("Você errou 3 vezes. Reiniciando a sequência.");
                shouldShowInfoPanel = true; // Defina para exibir o painel de informações após 3 tentativas incorretas
                RestartSequence();
            }

            return false;
        }

        currentNoteIndex++;

        if (!IsRepeating)
        {
            rodada++;
            print("a rodada é:" + rodada);
            if (!isPlaying)
            {
                isPlaying = true;
                currentNoteIndex = 0;
                incorrectAttempts = 0;
                
                if (sequenceCoroutine != null)
                {
                    StopCoroutine(sequenceCoroutine);
                }
                sequenceCoroutine = StartCoroutine(PlayNoteSequence(rodada));
            }
        }

        return true;
    }

    private IEnumerator PlayNoteSequence(int round)
    {
        
        if (round == 0)
        {
            foreach (var config in noteConfigs)
            {
                Color originalColor = config.noteKey.GetComponent<Image>().color;
                config.noteKey.GetComponent<Image>().color = config.pressedColor;
                soundManager.PlayNoteSound(config.noteKey.noteIndex, config.noteDuration);
                yield return new WaitForSeconds(config.noteDuration);
                config.noteKey.GetComponent<Image>().color = originalColor;
            }
            isPlaying = false;
        } else if (round == 1)
        {
            foreach (var config in noteConfigs2)
            {
                Debug.Log("Sequência repetida com sucesso!");
                Color originalColor = config.noteKey.GetComponent<Image>().color;
                config.noteKey.GetComponent<Image>().color = config.pressedColor;
                soundManager.PlayNoteSound(config.noteKey.noteIndex, config.noteDuration);
                yield return new WaitForSeconds(config.noteDuration);
                config.noteKey.GetComponent<Image>().color = originalColor;
            }
            isPlaying = false;
        }
        
    }

    private void RestartSequence()
    {
        currentNoteIndex = 0;
        isPlaying = false;
        incorrectAttempts = 0;

        if (incorrectAttempts >= maxIncorrectAttempts)
        {
            shouldShowInfoPanel = true; // Defina para exibir o painel de informações após 3 tentativas incorretas
        }

        // Chame a corrotina para controlar a exibição do painel e a repetição da sequência
        StartCoroutine(ShowInfoPanelAndRestart());
    }
    
     private IEnumerator ShowInfoPanelAndRestart()
    {
        if (shouldShowInfoPanel)
        {
            infoPanel.SetActive(true);

            // Aguarde por X segundos (substitua X pelo tempo desejado)
            float delayTime = 3.0f; // Exemplo: 5 segundos
            yield return new WaitForSeconds(delayTime);

            // Oculte o painel de informações
            infoPanel.SetActive(false);

            // Reinicie a sequência após o tempo definido
            StartNoteSequence();
        }
    }
}

