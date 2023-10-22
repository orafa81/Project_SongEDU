using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QualOIntrumento : MonoBehaviour
{

    public AudioSource somIntrumento;
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

    private int idInstrumento;

    void Start()
    {
        idInstrumento = 0;
        somIntrumento = GetComponent<AudioSource>();
        somIntrumento.clip =  sonsInstrumentos[idInstrumento];
        
        instrumentoA.sprite = instrumentosA[idInstrumento];
    
        instrumentoB.sprite = instrumentosB[idInstrumento];
    
        instrumentoC.sprite = instrumentosC[idInstrumento];

        instrumentoD.sprite = instrumentosD[idInstrumento];
        
    }

    
}
