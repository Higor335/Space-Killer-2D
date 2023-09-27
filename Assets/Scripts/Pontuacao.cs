using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    public TextMeshProUGUI pontuacaoTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pontuacao = FollowCameraVertical.pontuacao;
        pontuacaoTxt.text = pontuacao.ToString();
    }
}
