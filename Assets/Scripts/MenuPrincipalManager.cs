using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelDificuldade;
    public void Jogar()
    {
        Screen.SetResolution(1308, 669, true);

        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirDificuldade()
    {
        painelMenuInicial.SetActive(false);
        painelDificuldade.SetActive(true);
    }

    public void FecharDificuldade()
    {
        painelMenuInicial.SetActive(true);  
        painelDificuldade.SetActive(false);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void Fecharopcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
