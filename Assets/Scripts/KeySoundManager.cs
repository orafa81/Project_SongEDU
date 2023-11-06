using UnityEngine;

public class KeySoundManager : MonoBehaviour
{
    public AudioClip[] noteSounds;  // Um array de sons das notas

    private AudioSource audioSource;
    private float currentNoteEndTime = 0.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNoteSound(int noteIndex, float duration)
    {
        if (noteIndex >= 0 && noteIndex < noteSounds.Length)
        {
            if (Time.time < currentNoteEndTime)
            {
                // Uma nota est� tocando, vamos substituir pelo novo som
                audioSource.Stop();
            }
            print("TESTEANDO");
            audioSource.clip = noteSounds[noteIndex];
            audioSource.Play();
            
            currentNoteEndTime = Time.time + duration;
        }
    }
}
