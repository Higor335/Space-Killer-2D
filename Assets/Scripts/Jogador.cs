using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour{

    public AudioSource Correndo;
    public AudioSource Jetpack;
    public AudioSource MusicaJogo;
    public AudioSource DanoParede;
    public AudioSource Tiro;

    public float velocidadeVertical = 7.0f;
    private Animator anim;
    public int vida=0;
    private bool invisivel = false;
    bool jetpackAtivo = false;
    bool correndoAtivo = false;

    void Start(){
        MusicaJogo.Play();
        anim = GetComponent<Animator>();
        jetpackAtivo = false;
        correndoAtivo = false;
    }

    void Update(){
        float movimentoVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * movimentoVertical * velocidadeVertical * Time.deltaTime);

        if (transform.position.y < -3.65f){
            transform.position = new Vector3(transform.position.x, -3.65f, transform.position.z);
        }else if(transform.position.y > 3.88f){
            transform.position = new Vector3(transform.position.x, 3.88f, transform.position.z);
        }

        if (transform.position.y > -3.60f){
            if (!jetpackAtivo) {
                jetpackAtivo = true;
                correndoAtivo = false;
                Correndo.Stop();
                Jetpack.Play();
            }
            anim.Play("fly");
        }
        else{
            if (!correndoAtivo) {
                correndoAtivo = true;
                jetpackAtivo = false;
                Jetpack.Stop();
                Correndo.Play();
            }
            anim.Play("walk");
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        DanoParede.Play();
        GameObject colisor = collision.collider.gameObject;
        
        if(vida==1){
            MusicaJogo.Stop();
            Correndo.Stop();
            Jetpack.Stop();
            Time.timeScale = 0;//pausa o jogo
        }

        if (collision.gameObject.CompareTag("Obstaculo")){
            
            StartCoroutine(DesabilitaColisaoEpiscaJogador(collision.gameObject));
            vida--;
            string vidaa = vida+"";
            Debug.Log("colisão com obstáculo, Vida: "+vidaa);
        }
    }

    IEnumerator DesabilitaColisaoEpiscaJogador(GameObject obj){
        Collider2D collider = obj.GetComponent<Collider2D>();

        if (GetComponent<Renderer>() != null){
            collider.enabled = false;

            StartCoroutine(BlinkEffect());
            yield return new WaitForSeconds(1f);

            collider.enabled = true;
        }
    }

    IEnumerator BlinkEffect(){
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null){
            invisivel = true;
            int numBlinks = 5;

            for (int i = 0; i < numBlinks; i++){
                renderer.enabled = false;

                yield return new WaitForSeconds(0.1f);

                renderer.enabled = true;

                yield return new WaitForSeconds(0.1f);
            }

            invisivel = false;
        }
    }
}
