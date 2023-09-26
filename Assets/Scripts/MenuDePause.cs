using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string nomeMenuPrincipal;
    public static bool GamePausado = false;

    public GameObject menuPausaUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePausado)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        GamePausado = false;
    }
    void Pause()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        GamePausado = true;
    }

    public void VoltarParaMenu()

    {
        Time.timeScale = 1f;
        GamePausado = false;
        SceneManager.LoadScene(nomeMenuPrincipal);
            
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}