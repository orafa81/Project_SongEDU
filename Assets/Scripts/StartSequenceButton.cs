using UnityEngine;
using UnityEngine.UI;

public class StartSequenceButton : MonoBehaviour
{
    public SequenceManager sequenceManager;
    public Button startButton;
    public GameObject infoPanel;

    private void Start()
    {
        startButton.onClick.AddListener(StartSequence);
        infoPanel.SetActive(false);
    }

    private void StartSequence()
    {
        if (!sequenceManager.IsPlayingSequence)
        {
            infoPanel.SetActive(false);
            sequenceManager.shouldShowInfoPanel = false;
            sequenceManager.StartRepeatingAfterDelay(3f);
        }
    }
}

