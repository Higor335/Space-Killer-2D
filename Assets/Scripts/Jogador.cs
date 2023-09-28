using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Jogador : MonoBehaviour{

    public AudioSource Correndo;
    public AudioSource Jetpack;
    public AudioSource MusicaJogo;
    public AudioSource DanoParede;
    public AudioSource Tiro;

    public Image vida2;
    public Image vida1;
    public Image vida0;

    [SerializeField] private string nomeMenuPrincipal;

    public GameObject bulletPrefab; // Referência ao prefab da bala
    public float fireRate = 1.5f; // Intervalo entre cada tiro

    private float nextFire = 0.0f; // Tempo para o próximo tiro


    public float velocidadeVertical = 7.0f;
    private Animator anim;
    public int vida=0;
    bool jetpackAtivo = false;
    bool correndoAtivo = false;
    Color32 CorDano = new Color32(73, 10, 10, 255);

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

        if(PauseMenu.GamePausado){
            MusicaJogo.Pause();
            Correndo.Pause();
            Jetpack.Pause();
            DanoParede.Pause();
        } else {
            MusicaJogo.UnPause();
            Correndo.UnPause();
            Jetpack.UnPause();
            DanoParede.UnPause();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire) // Verifica se a barra de espaço foi pressionada e se o intervalo de tempo passou
        {
            nextFire = Time.time + fireRate; // Atualiza o tempo para o próximo tiro
            Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Obstaculo") || collision.gameObject.CompareTag("TiroMau")){
            DanoParede.Play();
            GameObject colisor = collision.collider.gameObject;
            
            if(vida==3){
                vida2.color = CorDano;
            }
            if(vida==2){
                vida1.color = CorDano;
            }
            if(vida==1){
                vida0.color = CorDano;
                MusicaJogo.Stop();
                Correndo.Stop();
                Jetpack.Stop();
                Boss.bossPresente = false;
                SceneManager.LoadScene(nomeMenuPrincipal);
            }
            
            StartCoroutine(DesabilitaColisaoEpiscaJogador(collision.gameObject));
            vida--;
            string vidaa = vida+"";
            Debug.Log("colisão com obstáculo, Vida: "+vidaa);
        }
    }

    IEnumerator DesabilitaColisaoEpiscaJogador(GameObject obj){
    Collider2D collider = obj.GetComponent<Collider2D>();

    if (collider != null && GetComponent<Renderer>() != null){
        collider.enabled = false;

        StartCoroutine(BlinkEffect());
        yield return new WaitForSeconds(1f);

        if (collider != null) // Verifica novamente antes de reativar o collider
            collider.enabled = true;
    }
}

    IEnumerator BlinkEffect(){
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null){
            int numBlinks = 5;

            for (int i = 0; i < numBlinks; i++){
                renderer.enabled = false;

                yield return new WaitForSeconds(0.1f);

                renderer.enabled = true;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void Shoot()
    {
        // Cria uma nova bala a partir do prefab na posição do jogador
        Tiro.Play();
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
