using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;


public class QualOIntrumento : MonoBehaviour
{

    public AudioSource somIntrumento;
    public Text nomeIntrumento;
    public Text txtPontos;
    public Image instrumentoA;
    public Image instrumentoB;
    public Image instrumentoC;
    public Image instrumentoD;
    

    public AudioClip[] sonsInstrumentos;
    public Sprite[] instrumentosA;
    public Sprite[] instrumentosB;
    public Sprite[] instrumentosC;
    public Sprite[] instrumentosD;
    public Sprite[] corretos;

    public string[] nomesInstrumentosA;
    public string[] nomesInstrumentosB;
    public string[] nomesInstrumentosC;
    public string[] nomesInstrumentosD;

    private int idInstrumento;
    private int pontos;

    private string svAlt;

    void Start()
    {
        idInstrumento = 0;
        pontos = 0;
        somIntrumento = GetComponent<AudioSource>();
        somIntrumento.clip =  sonsInstrumentos[idInstrumento];
        
        instrumentoA.sprite = instrumentosA[idInstrumento];
    
        instrumentoB.sprite = instrumentosB[idInstrumento];
    
        instrumentoC.sprite = instrumentosC[idInstrumento];

        instrumentoD.sprite = instrumentosD[idInstrumento];

        txtPontos.text = "Acertos: " + pontos.ToString();
    }

    public void selecioneInstrumento(string alternativa){
         
        if (alternativa == "A")
        {
            nomeIntrumento.text = nomesInstrumentosA[idInstrumento];
            if (instrumentosA[idInstrumento] == corretos[idInstrumento])
            {
                svAlt = alternativa;
            }
        } else if (alternativa == "B")
        {
            nomeIntrumento.text = nomesInstrumentosB[idInstrumento];
            if (instrumentosB[idInstrumento] == corretos[idInstrumento])
            {
                svAlt = alternativa;
            }
        } else if (alternativa == "C")
        {
            nomeIntrumento.text = nomesInstrumentosC[idInstrumento];
            if (instrumentosC[idInstrumento] == corretos[idInstrumento])
            {
                svAlt = alternativa;
            }
        } else if (alternativa == "D")
        {
            nomeIntrumento.text = nomesInstrumentosD[idInstrumento];
            if (instrumentosD[idInstrumento] == corretos[idInstrumento])
            {
                
                svAlt = alternativa;
            }
        }
        
    }

    public void proximaPergunta(){
        string alter = svAlt;
        if (alter == "A")
        {
            print("Teste");
            pontos++;
        } else if (alter == "B")
        {
            pontos++;
        } else if (alter == "C")
        {
            pontos++;
        } else if (alter == "D")
        {
            pontos++;
        }
        idInstrumento++;
        somIntrumento.clip =  sonsInstrumentos[idInstrumento];
        instrumentoA.sprite = instrumentosA[idInstrumento];
        instrumentoB.sprite = instrumentosB[idInstrumento];
        instrumentoC.sprite = instrumentosC[idInstrumento];
        instrumentoD.sprite = instrumentosD[idInstrumento];
        txtPontos.text = "Acertos: " + pontos.ToString();
    }
}
