using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    private float audioSourceAtual;
    private void Start()
    {
        // Configura o valor inicial do slider com o volume atual
        volumeSlider.value = audioSource.volume;

        // Configura o listener de mudança de valor do slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        // Atualiza o volume do AudioSource com base no valor do slider
        audioSource.volume = volume;
    }

    public void AudioMute()
    {
        if (audioSource.volume != 0)
        {
            audioSourceAtual = audioSource.volume;
            audioSource.volume = 0;
        } else
        {
            audioSource.volume = audioSourceAtual;
        }
        
    }

}
