using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruController : MonoBehaviour
{
    public AudioSource[] audioSources;

    private AudioSource currentAudioSource;

    private void Start()
    {
        // Pausa todas as m�sicas no in�cio
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    public void OnButtonClick(AudioSource clickedAudioSource)
    {
        // Se o mesmo bot�o for clicado novamente, para a m�sica
        if (currentAudioSource == clickedAudioSource)
        {
            clickedAudioSource.Stop();
            currentAudioSource = null;
        }
        else
        {
            // Pausa a m�sica atualmente tocando (se houver)
            if (currentAudioSource != null)
            {
                currentAudioSource.Stop();
            }

            // Toca a m�sica do bot�o clicado
            clickedAudioSource.Play();
            currentAudioSource = clickedAudioSource;
        }
    }
}
