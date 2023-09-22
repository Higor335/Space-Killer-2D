using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour{

    public float velocidadeVertical = 7.0f; // Velocidade de movimento vertical
    private Animator anim; // Referência para o componente Animator
    public int vida=0;
    private bool invisivel = false;

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
        if (transform.position.y > -3.60f){
            anim.Play("fly"); // Inicia a animação "fly"
        }
        else{
            anim.Play("walk"); // Inicia a animação "idle" (ou o nome da sua animação de repouso)
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        GameObject colisor = collision.collider.gameObject;
        
        if(vida==1){
            Time.timeScale = 0;//pausa o jogo
        }

        if (collision.gameObject.CompareTag("Obstaculo")){
            
            //modifica a visibilidade do obstaculo para false por 1 segundo e depois true
            StartCoroutine(DesabilitaColisaoEpiscaJogador(collision.gameObject));
            vida--;
            string vidaa = vida+"";
            Debug.Log("colisão com obstáculo, Vida: "+vidaa);
        }
    }

    IEnumerator DesabilitaColisaoEpiscaJogador(GameObject obj){
        //desativa o colider do objeto
        
        Collider2D collider = obj.GetComponent<Collider2D>();

        if (GetComponent<Renderer>() != null){
            collider.enabled = false;

            //Efeito de piscar quando tomou dano 
            StartCoroutine(BlinkEffect());
            yield return new WaitForSeconds(1f);

            collider.enabled = true;
        }
    }

    IEnumerator BlinkEffect(){
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null){
            invisivel = true; // O jogador está temporariamente invisivel
            int numBlinks = 5; // Número de vezes que o personagem piscará

            for (int i = 0; i < numBlinks; i++){
                renderer.enabled = false;

                yield return new WaitForSeconds(0.1f);

                renderer.enabled = true;

                yield return new WaitForSeconds(0.1f);
            }

            invisivel = false; // O jogador não está mais invisivel
        }
    }
}
