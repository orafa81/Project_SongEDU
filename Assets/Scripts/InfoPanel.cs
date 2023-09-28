using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    private void Start()
    {
        // Certifique-se de que o painel de informações esteja desativado no início
        gameObject.SetActive(false);
    }

    public void ShowInfo()
    {
        // Ative o painel de informações
        gameObject.SetActive(true);
    }

    public void HideInfo()
    {
        // Desative o painel de informações
        gameObject.SetActive(false);
    }
}

