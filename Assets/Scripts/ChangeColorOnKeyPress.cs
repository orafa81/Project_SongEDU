using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;



public class ChangeColorOnKeyPress : MonoBehaviour
{
    public Button button;
    public KeyCode targetKey;
    public Color pressedColor;
    private Color originalColor;
    public AudioSource noteSound;
    public float releaseTime = 0.1f; // Tempo em segundos antes de parar de tocar o som
    public float maxNoteDuration = 2.0f;


    private AudioSource audioSource;
    private bool isPlaying;
    private float releaseTimer;
    private bool buttonPressed;
    private float lastClickTime;
    private float noteStartTime;


    private void Start()
    {
        // Armazena a cor original do botão
        originalColor = button.image.color;

        audioSource = GetComponent<AudioSource>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void Update()
    {
        // Verifica se a tecla alvo foi pressionada
        if (Input.GetKeyDown(targetKey))
        {
            // Altera a cor do botão para a cor pressionada
            button.image.color = pressedColor;
        }

        // Verifica se a tecla alvo foi solta
        if (Input.GetKeyUp(targetKey))
        {
            // Restaura a cor original do botão
            button.image.color = originalColor;
        }

        if (buttonPressed)
        {
            if (!isPlaying)
            {
                PlayNote();
            }
        }
        else if (isPlaying)
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

        if (isPlaying && Time.time - noteStartTime >= maxNoteDuration)
        {
            StopNote();
        }
    }

    private void PlayNote()
    {
        isPlaying = true;
        audioSource = noteSound;
        audioSource.Play();
        noteStartTime = Time.time;

    }

    private void StopNote()
    {
        isPlaying = false;
        audioSource.Stop();
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        PlayNote();
        releaseTimer = float.MaxValue; // Definir o tempo de liberação como um valor alto para que a nota não pare automaticamente
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        releaseTimer = releaseTime;
    }*/

    private void OnButtonClicked()
    {
        float currentTime = Time.time;

        if (currentTime - lastClickTime > releaseTime)
        {
            PlayNote();
            lastClickTime = currentTime;
        }
        else
        {
            buttonPressed = !buttonPressed;
            lastClickTime = 0f;
        }
    }
}


