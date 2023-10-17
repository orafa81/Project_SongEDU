using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject correctInstrument; // Este é o instrumento correto que o jogador deve escolher.

    public void CheckAnswer(Button buttonClicked)
    {
        if (buttonClicked.gameObject == correctInstrument)
        {
            // A resposta está correta. Exiba o contorno verde no objeto do instrumento correto.
            
            Debug.Log("Resposta correta!");
        }
        else
        {
            // A resposta está errada. Exiba o contorno vermelho no botão clicado.
            
            Debug.Log("Resposta incorreta.");
        }
    }
}
