using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidadeVertical = 5.0f; // Velocidade de movimento vertical
    private Animator anim; // Referência para o componente Animator

    void Start(){
        anim = GetComponent<Animator>(); // Obtém o componente Animator
    }

    void Update()
    {
        float movimentoVertical = Input.GetAxis("Vertical"); // Captura a entrada vertical (seta para cima ou "W")

        // Movimento vertical
        transform.Translate(Vector3.up * movimentoVertical * velocidadeVertical * Time.deltaTime);

        // Verifica se o jogador está se movendo para cima e executa a animação correspondente
        if (movimentoVertical > 0)
        {
            anim.Play("fly"); // Inicia a animação "fly"
        }
        else
        {
            anim.Play("walk"); // Inicia a animação "idle" (ou o nome da sua animação de repouso)
        }
    }
}
