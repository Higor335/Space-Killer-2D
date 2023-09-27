using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelDificuldade;

    public static string dificuldade = "medio";

    public Button btFacil, btMedio, btDificil;

    void Start()
    {
        // Listener dos botões
        btFacil.onClick.AddListener(() => SelecionarDificuldade(btFacil));
        btMedio.onClick.AddListener(() => SelecionarDificuldade(btMedio));
        btDificil.onClick.AddListener(() => SelecionarDificuldade(btDificil));
    }

    public void Jogar()
    {
        Screen.SetResolution(1308, 669, true);

        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void SelecionarDificuldade(Button button)
    {
        switch (button.name)
        {
            case "btFacil":
                dificuldade = "facil";
                Debug.Log(dificuldade);
                Jogar();
                break;
            case "btMedio":
                dificuldade = "medio";
                Debug.Log(dificuldade);
                Jogar();
                break;
            case "btDificil":
                dificuldade = "dificil";
                Debug.Log(dificuldade);
                Jogar();
                break;
        }
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
