using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teclado : MonoBehaviour
{
    public KeyCode key;
    public AudioSource noteSound;
    public float releaseTime = 0.1f; // Tempo em segundos antes de parar de tocar o som

    private AudioSource audioSource;
    private bool isPlaying;
    private float releaseTimer;
    private bool keyPressed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key) && !keyPressed)
        {
            PlayNote();
            keyPressed = true;
        }

        if (Input.GetKey(key) && isPlaying)
        {
            releaseTimer = releaseTime;
        }

        if (Input.GetKeyUp(key) && isPlaying)
        {
            releaseTimer = releaseTime;
        }

        if (releaseTimer > 0)
        {
            releaseTimer -= Time.deltaTime;
            if (releaseTimer <= 0)
            {
                StopNote();
            }
        }

        if (Input.GetKeyUp(key))
        {
            keyPressed = false;
        }
    }

    private void PlayNote()
    {
        isPlaying = true;
        audioSource = noteSound;
        audioSource.Play();
    }

    private void StopNote()
    {
        isPlaying = false;
        audioSource.Stop();
    }

}
