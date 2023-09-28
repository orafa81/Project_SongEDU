using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject MenuInicial;
    public GameObject MenuOpcoes;
    

    

    public void LoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void AbrirOpcoes()
    {
        MenuOpcoes.SetActive(true);
       
    }

    public void FecharOpcoes()
    {
        MenuOpcoes.SetActive(false);
        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

    
}
