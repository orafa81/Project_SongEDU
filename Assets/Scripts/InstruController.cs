using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruController : MonoBehaviour
{
    public AudioSource[] audioSources;

    private AudioSource currentAudioSource;

    private void Start()
    {
        // Pausa todas as músicas no início
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    public void OnButtonClick(AudioSource clickedAudioSource)
    {
        // Se o mesmo botão for clicado novamente, para a música
        if (currentAudioSource == clickedAudioSource)
        {
            clickedAudioSource.Stop();
            currentAudioSource = null;
        }
        else
        {
            // Pausa a música atualmente tocando (se houver)
            if (currentAudioSource != null)
            {
                currentAudioSource.Stop();
            }

            // Toca a música do botão clicado
            clickedAudioSource.Play();
            currentAudioSource = clickedAudioSource;
        }
    }
}
