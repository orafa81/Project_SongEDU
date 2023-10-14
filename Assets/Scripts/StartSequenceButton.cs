using UnityEngine;
using UnityEngine.UI;

public class StartSequenceButton : MonoBehaviour
{
    public SequenceManager sequenceManager;
    public Button startButton;
    public GameObject infoPanel; // Adicione uma refer�ncia ao painel de informa��es

    private void Start()
    {
        startButton.onClick.AddListener(StartSequence);
        infoPanel.SetActive(false); // Certifique-se de que o painel de informa��es esteja desativado inicialmente
    }

    private void StartSequence()
    {
        if (!sequenceManager.IsPlayingSequence)
        {
            // Desative o painel de informa��es antes de iniciar a sequ�ncia manualmente
            infoPanel.SetActive(false);
            sequenceManager.StartNoteSequence();
        }
    }
}

