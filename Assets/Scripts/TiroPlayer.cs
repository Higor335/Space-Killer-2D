using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : MonoBehaviour{
    public float bulletSpeed = 20f; // Velocidade da bala

    void Update(){
        // Move a bala para a direita
        transform.position += Vector3.right * bulletSpeed * Time.deltaTime;
    }

    void OnBecameInvisible(){
        // Destroi a bala quando ela sai da tela
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Obstaculo") || 
        collision.gameObject.CompareTag("Inimigo") || 
        collision.gameObject.CompareTag("Boss"))
    {
        Destroy(gameObject);
    }
}

}
