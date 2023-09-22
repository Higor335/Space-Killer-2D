using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidadeVertical = 7.0f; // Velocidade de movimento vertical
    private Animator anim; // Referência para o componente Animator

    void Start(){
        anim = GetComponent<Animator>(); // Obtém o componente Animator
    }

    void Update(){


        float movimentoVertical = Input.GetAxis("Vertical"); // Captura a entrada vertical (seta para cima ou "W")

        // Movimento vertical
        transform.Translate(Vector3.up * movimentoVertical * velocidadeVertical * Time.deltaTime);

        // Verifica se a posição do jogador é menor que -3.65
        if (transform.position.y < -3.65f){
            transform.position = new Vector3(transform.position.x, -3.65f, transform.position.z);
        }else if(transform.position.y > 3.88f){
            transform.position = new Vector3(transform.position.x, 3.88f, transform.position.z);
        }

        // Verifica se o jogador está se movendo para cima e executa a animação correspondente
        if (transform.position.y > -3.60f)
        {
            anim.Play("fly"); // Inicia a animação "fly"
        }
        else
        {
            anim.Play("walk"); // Inicia a animação "idle" (ou o nome da sua animação de repouso)
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo")){
            anim.Play("walk");
            Time.timeScale = 0; // Pausa o jogo
            Debug.Log("Jogo pausado por colisão com obstáculo.");
            // Aqui você pode adicionar qualquer outra ação que queira quando o jogador colide com um obstáculo.
        }
    }


}
