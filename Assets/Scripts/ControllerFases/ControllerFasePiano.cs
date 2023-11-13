using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFasePiano : MonoBehaviour
{
    public GameObject painelFases1;
    public GameObject painelFases2;
    public GameObject btnModos;

    public GameObject estrelaOn1;
    public GameObject estrelaOn2;
    public GameObject estrelaOn3;

    private int modoDeJogo;
    private int modoDeJogoAtual;
    void Start()
    {
        painelFases1.SetActive(false);
        painelFases2.SetActive(false);
        btnModos.SetActive(true);
        estrelaOn1.SetActive(false);
        estrelaOn2.SetActive(false);
        estrelaOn3.SetActive(false);
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

   
}
