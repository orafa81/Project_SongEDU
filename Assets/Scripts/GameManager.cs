using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject correctInstrument; // Este é o instrumento correto que o jogador deve escolher.
    public Image outlineImage; // A imagem de contorno.

    public void CheckAnswer(Button buttonClicked)
    {
        if (buttonClicked.gameObject == correctInstrument)
        {
            // A resposta está correta. Exiba o contorno verde no objeto do instrumento correto.
            outlineImage.color = Color.green;
            Debug.Log("Resposta correta!");
        }
        else
        {
            // A resposta está errada. Exiba o contorno vermelho no botão clicado.
            outlineImage.color = Color.red;
            Debug.Log("Resposta incorreta.");
        }
    }
}
