using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour{

    private float videoDuration = 10.8f;

    
    void Start(){
        Invoke("CarregarJogo", videoDuration);
    }

    void CarregarJogo(){
        SceneManager.LoadScene("MenuPrincipal");
    }
}
