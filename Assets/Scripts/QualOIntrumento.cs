using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QualOIntrumento : MonoBehaviour
{
    public string nomeDaCenaAtual;
    
    public AudioSource somIntrumento;
    // public AudioSource somIntrumentoA;
    // public AudioSource somIntrumentoB;
    // public AudioSource somIntrumentoC;
    // public AudioSource somIntrumentoD;
    public Text nomeIntrumento;
    public Text txtPontos;
    public Image instrumentoA;
    public Image instrumentoB;
    public Image instrumentoC;
    public Image instrumentoD;
    

    public AudioClip[] sonsInstrumentos;
    // public AudioClip[] sonsInstrumentosA;
    // public AudioClip[] sonsInstrumentosB;
    // public AudioClip[] sonsInstrumentosC;
    // public AudioClip[] sonsInstrumentosD;
    public Sprite[] instrumentosA;
    public Sprite[] instrumentosB;
    public Sprite[] instrumentosC;
    public Sprite[] instrumentosD;
    public Sprite[] corretos;

    public string[] nomesInstrumentosA;
    public string[] nomesInstrumentosB;
    public string[] nomesInstrumentosC;
    public string[] nomesInstrumentosD;
    
    public GameObject[] feedBackErros;

    private int idInstrumento;
    private int pontos;
    private int erros;

    private string svAlt;

    void Start()
    {
        idInstrumento = 0;
        pontos = 0;
        somIntrumento = GetComponent<AudioSource>();
        somIntrumento.clip =  sonsInstrumentos[idInstrumento];
        // somIntrumentoA.clip =  sonsInstrumentosA[idInstrumento];
        // somIntrumentoB.clip =  sonsInstrumentosB[idInstrumento];
        // somIntrumentoC.clip =  sonsInstrumentosC[idInstrumento];
        // somIntrumentoD.clip =  sonsInstrumentosD[idInstrumento];
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
            svAlt = alternativa;
            
        } else if (alternativa == "B")
        {
            nomeIntrumento.text = nomesInstrumentosB[idInstrumento];
            svAlt = alternativa;
            
        } else if (alternativa == "C")
        {
            nomeIntrumento.text = nomesInstrumentosC[idInstrumento];
            svAlt = alternativa;
        } else if (alternativa == "D")
        {
            nomeIntrumento.text = nomesInstrumentosD[idInstrumento];
            svAlt = alternativa;
        }
        
    }

    public void proximaPergunta(){
        string alter = svAlt;
        print(idInstrumento);
        if (alter == "A")
        {
            if (instrumentosA[idInstrumento] == corretos[idInstrumento])
            {
                pontos++;
                idInstrumento++;
                svAlt = "";
                somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                instrumentoA.sprite = instrumentosA[idInstrumento];
                instrumentoB.sprite = instrumentosB[idInstrumento];
                instrumentoC.sprite = instrumentosC[idInstrumento];
                instrumentoD.sprite = instrumentosD[idInstrumento];
                txtPontos.text = "Acertos: " + pontos.ToString();
            }
            else
            {
                erros++;
            }
        } else if (alter == "B")
        {
            if (instrumentosB[idInstrumento] == corretos[idInstrumento])
            {
                pontos++;
                idInstrumento++;
                svAlt = "";
                somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                instrumentoA.sprite = instrumentosA[idInstrumento];
                instrumentoB.sprite = instrumentosB[idInstrumento];
                instrumentoC.sprite = instrumentosC[idInstrumento];
                instrumentoD.sprite = instrumentosD[idInstrumento];
                txtPontos.text = "Acertos: " + pontos.ToString();
            }else
            {
                erros++;
            }
        } else if (alter == "C")
        {
            if (instrumentosC[idInstrumento] == corretos[idInstrumento])
            {
                pontos++;
                idInstrumento++;
                svAlt = "";
                somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                instrumentoA.sprite = instrumentosA[idInstrumento];
                instrumentoB.sprite = instrumentosB[idInstrumento];
                instrumentoC.sprite = instrumentosC[idInstrumento];
                instrumentoD.sprite = instrumentosD[idInstrumento];
                txtPontos.text = "Acertos: " + pontos.ToString();
                
            } else
            {
                erros++;
            }
        } else if (alter == "D")
        {
            if (instrumentosD[idInstrumento] == corretos[idInstrumento])
            {
                pontos++;
                idInstrumento++;
                svAlt = "";
                somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                instrumentoA.sprite = instrumentosA[idInstrumento];
                instrumentoB.sprite = instrumentosB[idInstrumento];
                instrumentoC.sprite = instrumentosC[idInstrumento];
                instrumentoD.sprite = instrumentosD[idInstrumento];
                txtPontos.text = "Acertos: " + pontos.ToString();
            } else
            {
                erros++;
            }
        }
        if (erros == 1)
        {
            feedBackErros[erros-1].SetActive(false);
        } else if (erros == 2)
        {
            feedBackErros[erros-1].SetActive(false);
        } else if (erros == 3)
        {
            feedBackErros[erros-1].SetActive(false);
            print(erros);
            SceneManager.LoadScene (nomeDaCenaAtual);
        }
        
        
    }

    private void verificaErros(){
        if (erros == 3)
        {
            SceneManager.LoadScene (nomeDaCenaAtual);
        }
    }

}
