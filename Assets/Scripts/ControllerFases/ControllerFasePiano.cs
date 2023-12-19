using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro.Examples;

public class ControllerFasePiano : MonoBehaviour
{
    public GameObject painelFases1;
    public GameObject painelFases2;
    public GameObject btnModos;
    public Text textPontos;

    public GameObject estrelaOn1;
    public GameObject estrelaOn2;
    public GameObject estrelaOn3;

    private int modoDeJogo;
    private int modoDeJogoAtual;
    private int pontuacaoSalva;
    void Start()
    {
        painelFases1.SetActive(false);
        painelFases2.SetActive(false);
        btnModos.SetActive(true);
        estrelaOn1.SetActive(false);
        estrelaOn2.SetActive(false);
        estrelaOn3.SetActive(false);
        pontuacaoSalva = PlayerPrefs.GetInt("PontuacaoQuiz1", 0);
    }

    public void controlaPainel(int modo){
        if (modo == 1)
        {
            painelFases1.SetActive(true);
            btnModos.SetActive(false);
            modoDeJogoAtual = modo;
        } else if (modo == 2)
        {
            painelFases2.SetActive(true);
            btnModos.SetActive(false);
            modoDeJogoAtual = modo;
        }
    }

    public void controlaFase(string nameFases){
        if (nameFases == "QF1")
        {
            SceneManager.LoadScene(nameFases);
        }
    }

    public void testePontos(){
        SceneManager.LoadScene("MenuModelos");
    }

    private void estrelasFases(){
        if (notaFinal == 10)
        {
            estrelasOn[0].SetActive(true);
            estrelasOn[1].SetActive(true);
            estrelasOn[2].SetActive(true);
            
        }else if (notaFinal > 6 && notaFinal < 10)
        {
            estrelasOn[0].SetActive(true);
            estrelasOn[1].SetActive(true);
            
        }
        else if (notaFinal <= 6 && notaFinal > 0)
        {
            estrelasOn[0].SetActive(true);
            
        }
    }
}
