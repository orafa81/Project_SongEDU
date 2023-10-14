using UnityEngine;
using UnityEngine.UI;

public class StartSequenceButton : MonoBehaviour
{
    public SequenceManager sequenceManager;
    public Button startButton;
    public GameObject infoPanel; // Adicione uma referência ao painel de informações

    private void Start()
    {
        startButton.onClick.AddListener(StartSequence);
        infoPanel.SetActive(false); // Certifique-se de que o painel de informações esteja desativado inicialmente
    }

    private void StartSequence()
    {
        if (!sequenceManager.IsPlayingSequence)
        {
            // Desative o painel de informações antes de iniciar a sequência manualmente
            infoPanel.SetActive(false);
            sequenceManager.StartNoteSequence();
        }
    }
}

