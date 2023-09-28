using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Inimigo1Prefab;
    public GameObject Inimigo2Prefab;
    public GameObject Inimigo3Prefab;

    public GameObject Boss1Prefab;
    public GameObject Boss2Prefab;
    public GameObject Boss3Prefab;

    public float minY = -3.65f;
    public float maxY = 3.88f;
    public float speed = 1.0f;

    private Transform cameraTransform;
    private bool bossPresente = Boss.bossPresente;
    private int ContadorParaBoss = 0;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        InvokeRepeating("SpawnEnemyWithDelay", Random.Range(8f, 12f), Random.Range(8f, 12f));
    }

    void SpawnEnemyWithDelay(){
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        if (inimigos.Length == 0 && !Boss.bossPresente){
            ContadorParaBoss++;
            if(ContadorParaBoss == 4){
                GerarBoss();
                ContadorParaBoss = 0;
            }else{
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        float newY = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
        Vector3 targetPosition = new Vector3(cameraTransform.position.x, newY, transform.position.z);
        transform.position = targetPosition;

        int randomEnemy = Random.Range(1, 4);

        switch (randomEnemy)
        {
            case 1:
                Instantiate(Inimigo1Prefab, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Inimigo2Prefab, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Inimigo3Prefab, transform.position, Quaternion.identity);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiro"))
        {
            Debug.Log("tomou"); 

            int hitsNeeded = 0;
            string dificuldade = MenuPrincipalManager.dificuldade;

            switch (dificuldade){
                case "facil":
                    hitsNeeded = 3;
                    break;
                case "medio":
                    hitsNeeded = 5;
                    break;
                case "dificil":
                    hitsNeeded = 8;
                    break;
            }
            Debug.Log(hitsNeeded);
        }
    }

    void GerarBoss(){
    Boss.bossPresente = true;
    GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");

    float newY = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
    Vector3 targetPosition = new Vector3(cameraTransform.position.x, newY, 0);
    transform.position = targetPosition;

    int randomBoss = Random.Range(1, 4);
    GameObject bossPrefab = null;

    switch (randomBoss)
    {
        case 1:
            bossPrefab = Boss1Prefab;
            break;
        case 2:
            bossPrefab = Boss2Prefab;
            break;
        case 3:
            bossPrefab = Boss3Prefab;
            break;
    }

    if (bossPrefab != null)
    {
        Quaternion bossRotation = bossPrefab.transform.rotation;
        Instantiate(bossPrefab, targetPosition, bossRotation);
    }
}
}