using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro.Examples;

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
    public NoteConfig[] noteConfigs3;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public Text numAcertos;
    private KeySoundManager soundManager;
    private Coroutine sequenceCoroutine;
    private int currentNoteIndex = 0;
    private int incorrectAttempts = 0;
    private int maxIncorrectAttempts = 3;
    private int rodada = 0;
    private bool isPlaying = false;
    private bool shouldShowInfoPanel = false; // Flag para mostrar o painel de informações
    private float valor;
    private int erros;
    private float media;
    private NoteKey meusAcertos;
    public GameObject infoPanel; // Adicione uma referência ao painel de informações no Inspector

    public bool IsPlayingSequence { get { return isPlaying; } }
    public bool IsRepeating { get { return currentNoteIndex < noteConfigs.Length; } }
    public bool IsRepeating2 { get { return currentNoteIndex < noteConfigs2.Length; } }

    
    private void Start()
    {
        soundManager = FindObjectOfType<KeySoundManager>();
        valor = 0f;
        erros = 0;
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
        if (rodada == 0)
        {
            if (!IsRepeating)
            {
                Debug.Log("O jogador tentou tocar mais notas do que a sequência alvo.");
                return false;
            }

            if (noteConfigs[currentNoteIndex].noteKey.noteIndex != playerNoteIndex)
            {
                Debug.Log("Erro! A nota tocada está incorreta.");
                erros++;
                if (erros == 1)
                {
                    vida3.SetActive(false);
                }else if (erros == 2)
                {
                    vida3.SetActive(false);
                    vida2.SetActive(false);
                } else if (erros == 3)
                {
                    vida3.SetActive(false);
                    vida2.SetActive(false);
                    vida1.SetActive(false); 
                }
                incorrectAttempts++;

                if (incorrectAttempts >= maxIncorrectAttempts || erros == 3)
                {
                    Debug.Log("Você errou 3 vezes. Reiniciando a sequência.");
                    valor = 0;
                    rodada = 0;
                    shouldShowInfoPanel = true; // Defina para exibir o painel de informações após 3 tentativas incorretas
                    RestartSequence();
                }

                return false;
            } else if (noteConfigs[currentNoteIndex].noteKey.noteIndex == playerNoteIndex)
            {
                valor++;
                numAcertos.text = "Acertos: " + valor.ToString();
            }

            currentNoteIndex++;

            if (!IsRepeating)
            {
                rodada++;
                //print("a rodada é:" + rodada);
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

            
        } else if (rodada == 1)
        {
            
            if (!IsRepeating2)
            {
                Debug.Log("O jogador tentou tocar mais notas do que a sequência alvo.");
                return false;
            }

            if (noteConfigs2[currentNoteIndex].noteKey.noteIndex != playerNoteIndex)
            {
                Debug.Log("Erro! A nota tocada está incorreta.");
                erros++;
                if (erros == 1)
                {
                    vida3.SetActive(false);
                }else if (erros == 2)
                {
                    vida3.SetActive(false);
                    vida2.SetActive(false);
                } else if (erros == 3)
                {
                    vida3.SetActive(false);
                    vida2.SetActive(false);
                    vida1.SetActive(false); 
                }
                incorrectAttempts++;

                if (incorrectAttempts >= maxIncorrectAttempts || erros == 3)
                {
                    Debug.Log("Você errou 3 vezes. Reiniciando a sequência.");
                    valor = 0;
                    rodada = 0;
                    shouldShowInfoPanel = true; // Defina para exibir o painel de informações após 3 tentativas incorretas
                    RestartSequence();
                }

                return false;
            } else if (noteConfigs2[currentNoteIndex].noteKey.noteIndex == playerNoteIndex)
            {
                valor++;
                numAcertos.text = "Acertos: " + valor.ToString();
            }

            currentNoteIndex++;

            if (!IsRepeating2)
            {
                rodada++;
                // print("a rodada é:" + rodada);
                // if (!isPlaying)
                // {
                //     isPlaying = true;
                //     currentNoteIndex = 0;
                //     incorrectAttempts = 0;
                    
                //     if (sequenceCoroutine != null)
                //     {
                //         StopCoroutine(sequenceCoroutine);
                //     }
                //     sequenceCoroutine = StartCoroutine(PlayNoteSequence(rodada));
                // }
                int numSequencias = noteConfigs.Length + noteConfigs2.Length;
                float notaFinal;
                media = (10 * (valor/numSequencias)) - (erros * 2);
                notaFinal = Mathf.RoundToInt(media);
                Debug.Log("Minha nota final: " + notaFinal);
                
            }

            
        } 
        return true;
        
    }

    private IEnumerator PlayNoteSequence(int round)
    {
        
        if (round == 0)
        {
            yield return new WaitForSeconds(3.0f);
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
            yield return new WaitForSeconds(3.0f);
            foreach (var config in noteConfigs2)
            {
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

