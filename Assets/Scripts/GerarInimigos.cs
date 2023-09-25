using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Inimigo1Prefab;
    public GameObject Inimigo2Prefab;
    public GameObject Inimigo3Prefab;

    public float minY = -3.65f;
    public float maxY = 3.88f;
    public float speed = 1.0f;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        InvokeRepeating("SpawnEnemyWithDelay", Random.Range(5f, 12f), Random.Range(5f, 12f));
    }

    void SpawnEnemyWithDelay()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        if (inimigos.Length == 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float newY = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
        Vector3 targetPosition = new Vector3(cameraTransform.position.x, newY, transform.position.z);
        transform.position = targetPosition;

        // Gera um número aleatório entre 1 e 3
        int randomEnemy = Random.Range(1, 4);

        // Instancia o inimigo correspondente ao número gerado
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
}
