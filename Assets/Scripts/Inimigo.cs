using UnityEngine;

public class FollowCameraVertical : MonoBehaviour
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

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update(){
        float newY = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
        Vector3 newPosition = transform.position;
        newPosition.x = cameraTransform.position.x + offsetX; // Ajuste de posição x
        newPosition.y = newY;
        transform.position = newPosition;

        if (Time.time - tempoUltimoDisparo >= intervaloDeDisparo)
        {
            Disparar(); // Chama a função de disparo
            tempoUltimoDisparo = Time.time; // Atualiza o tempo do último disparo
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Tiro")){
            Debug.Log("tomou");
            hitsTaken++;
            if (hitsTaken == 5){
                Destroy(gameObject); // Destruir o inimigo após 3 tiros
            }
        }
    }

    void Disparar()
    {
        // Cria o objeto tiro
        GameObject tiro = Instantiate(tiroPrefab, transform.position, Quaternion.identity);
        
        // Aqui você pode configurar a velocidade ou direção do tiro, se necessário
        // Exemplo: tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 0.0f);
    }
}
