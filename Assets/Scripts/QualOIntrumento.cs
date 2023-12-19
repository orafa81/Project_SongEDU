using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QualOIntrumento : MonoBehaviour
{
    public string nomeDaCenaAtual;
    public int idFase;
    // public Color colorErro;    /*Atualizações Futuras*/
    // public Color colorNormal;
    public GameObject painelResultado;
    public GameObject menuBtn;
    public Button btnInstrumentoA;
    public Button btnInstrumentoB;
    public Button btnInstrumentoC;
    public Button btnInstrumentoD;
    public AudioSource somIntrumento;
    public AudioSource somIntrumentoA;
    public AudioSource somIntrumentoB;
    public AudioSource somIntrumentoC;
    public AudioSource somIntrumentoD;
    public Text nomeIntrumento;
    public Text txtFeedBack;
    public Text txtPontos;
    public Image instrumentoA;
    public Image instrumentoB;
    public Image instrumentoC;
    public Image instrumentoD;
    

    public AudioClip[] sonsInstrumentos;
    public AudioClip[] sonsInstrumentosA;
    public AudioClip[] sonsInstrumentosB;
    public AudioClip[] sonsInstrumentosC;
    public AudioClip[] sonsInstrumentosD;
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
    public GameObject[] estrelasOn;

    private int idInstrumento;
    
    private int questoes;
    private int pontos;
    private int erros;
    private int media;

    private int notaFinal;

    private string svAlt;

    void Start()
    {
        idInstrumento = 0;
        pontos = 0;
        erros = 0;
        questoes = sonsInstrumentos.Length;
        somIntrumento = GetComponent<AudioSource>();
        somIntrumento.clip =  sonsInstrumentos[idInstrumento];
        somIntrumento.Play();
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
            somIntrumentoA.clip =  sonsInstrumentosA[idInstrumento];
            somIntrumentoA.Play();
            svAlt = alternativa;
            
        } else if (alternativa == "B")
        {
            nomeIntrumento.text = nomesInstrumentosB[idInstrumento];
            somIntrumentoB.clip =  sonsInstrumentosB[idInstrumento];
            somIntrumentoB.Play();
            svAlt = alternativa;
            
        } else if (alternativa == "C")
        {
            nomeIntrumento.text = nomesInstrumentosC[idInstrumento];
            somIntrumentoC.clip =  sonsInstrumentosC[idInstrumento];
            somIntrumentoC.Play();
            svAlt = alternativa;
        } else if (alternativa == "D")
        {
            nomeIntrumento.text = nomesInstrumentosD[idInstrumento];
            somIntrumentoD.clip =  sonsInstrumentosD[idInstrumento];
            somIntrumentoD.Play();
            svAlt = alternativa;
        } else if (alternativa == "R")
        {
            somIntrumento.clip =  sonsInstrumentos[idInstrumento];
            somIntrumento.Play();
        }
        
    }

    public void proximaPergunta(){
        string alter = svAlt;
        if (idInstrumento < (questoes-1))
        {
            if (alter == "A")
            {
                if (instrumentosA[idInstrumento] == corretos[idInstrumento])
                {
                    pontos++;
                    idInstrumento++;
                    svAlt = "";
                    nomeIntrumento.text = "Qual é o Instrumento?";
                    somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                    somIntrumento.Play();
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
                    nomeIntrumento.text = "Qual é o Instrumento?";
                    somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                    somIntrumento.Play();
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
                    nomeIntrumento.text = "Qual é o Instrumento?";
                    somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                    somIntrumento.Play();
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
                    nomeIntrumento.text = "Qual é o Instrumento?";
                    somIntrumento.clip =  sonsInstrumentos[idInstrumento];
                    somIntrumento.Play();
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
                SceneManager.LoadScene (nomeDaCenaAtual);
            }
        } else
        {
            if (alter == "A")
            {
                if (instrumentosA[idInstrumento] == corretos[idInstrumento])
                {
                    pontos++;
                    media = (10 * (pontos/questoes)) - (erros * 2);
                    notaFinal = Mathf.RoundToInt(media);
                    painelResultado.SetActive(true);
                    menuBtn.SetActive(false);
                    functionPainel();
                    PlayerPrefs.SetInt("PontuacaoQuiz" + idFase.ToString(), notaFinal);
                    PlayerPrefs.Save();
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
                    media = (10 * (pontos/questoes)) - (erros * 2);
                    notaFinal = Mathf.RoundToInt(media);
                    painelResultado.SetActive(true);
                    menuBtn.SetActive(false);
                    functionPainel();
                    PlayerPrefs.SetInt("PontuacaoQuiz" + idFase.ToString(), notaFinal);
                    PlayerPrefs.Save();
                }else
                {
                    erros++;
                }
            } else if (alter == "C")
            {
                if (instrumentosC[idInstrumento] == corretos[idInstrumento])
                {
                    pontos++;
                    media = (10 * (pontos/questoes)) - (erros * 2);
                    notaFinal = Mathf.RoundToInt(media);
                    painelResultado.SetActive(true);
                    menuBtn.SetActive(false);
                    functionPainel();
                    PlayerPrefs.SetInt("PontuacaoQuiz" + idFase.ToString(), notaFinal);
                    PlayerPrefs.Save();
                } else
                {
                    erros++;
                }
            } else if (alter == "D")
            {
                if (instrumentosD[idInstrumento] == corretos[idInstrumento])
                {
                    pontos++;
                    media = (10 * (pontos/questoes)) - (erros * 2);
                    notaFinal = Mathf.RoundToInt(media);
                    painelResultado.SetActive(true);
                    menuBtn.SetActive(false);
                    functionPainel();
                    PlayerPrefs.SetInt("PontuacaoQuiz" + idFase.ToString(), notaFinal);
                    PlayerPrefs.Save();
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
                SceneManager.LoadScene (nomeDaCenaAtual);
            }
        }  
    }

    private void functionPainel(){
        if (notaFinal == 10)
        {
            estrelasOn[0].SetActive(true);
            estrelasOn[1].SetActive(true);
            estrelasOn[2].SetActive(true);
            txtFeedBack.text = "Parabens, você é um RockStar!!";
        }else if (notaFinal > 6 && notaFinal < 10)
        {
            estrelasOn[0].SetActive(true);
            estrelasOn[1].SetActive(true);
            txtFeedBack.text = "Uuuh, foi quase. Continue tentando!";
        }
        else if (notaFinal <= 6 && notaFinal > 0)
        {
            estrelasOn[0].SetActive(true);
            txtFeedBack.text = "Mantenha o foco que voce chega lá.";
        }
        
    }
}
