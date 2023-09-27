using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    private float minY = -3.60f;
    private float maxY = 3.70f;
    public float speed = 1.0f;
    public float offsetX = 2.0f;

    public GameObject tiroPrefab; // Prefab do objeto redondo
    public float intervaloDeDisparo = 2.0f; // Intervalo entre os tiros

    private float tempoUltimoDisparo = 0.0f;

    private Transform cameraTransform;
    private int hitsTaken = 0;

    public static int pontuacao = 0;

    string dificuldade = MenuPrincipalManager.dificuldade; // Passagem da dificuldade static do script MenuPrincipalManager

    private bool invisivel = false;

    void Start(){
        cameraTransform = Camera.main.transform;
    }

    void Update(){
        float newY = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
        Vector3 newPosition = transform.position;
        newPosition.x = cameraTransform.position.x + offsetX; // Ajuste de posição x
        newPosition.y = newY;
        transform.position = newPosition;

        if (Time.time - tempoUltimoDisparo >= intervaloDeDisparo){
            Disparar(); // Chama a função de disparo
            tempoUltimoDisparo = Time.time; // Atualiza o tempo do último disparo
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Tiro")){
            Debug.Log("tomou"); 
            StartCoroutine(BlinkEffect());
            hitsTaken++; // Soma após inimigo colidir com um projétil

            int hitsNeeded = 0; // Variável que vai armazenar a vida do inimigo dependendo da dificuldade

            switch (dificuldade){
                case "facil":
                    hitsNeeded = 3; // vida do inimigo no modo fácil
                    break;
                case "medio":
                    hitsNeeded = 5; // vida do inimigo no modo medio
                    break;
                case "dificil":
                    hitsNeeded = 8; // vida do inimigo no modo difícil
                    break;
            }

            if (hitsTaken == hitsNeeded)
            {
                pontuacao++;
                Destroy(gameObject); // Destruir o inimigo após atingir o limite de tiros
            }
        }
    }

    void Disparar(){
        // Cria o objeto tiro
        GameObject tiro = Instantiate(tiroPrefab, transform.position, Quaternion.identity);
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
