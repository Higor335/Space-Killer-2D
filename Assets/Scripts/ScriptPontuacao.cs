using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptPontuacao : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI pontuacaoTxt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pontuacao = Inimigo.pontuacao;
        pontuacaoTxt.text = pontuacao.ToString();
    }
}
