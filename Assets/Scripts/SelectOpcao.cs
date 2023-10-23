using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOpcao : MonoBehaviour
{
    public Button btnConfirma;

    // Start is called before the first frame update
    void Start()
    {
        btnConfirma.interactable = false;
    }

    public void selecioneInstrumento (){
        btnConfirma.interactable = true;
    }
}
