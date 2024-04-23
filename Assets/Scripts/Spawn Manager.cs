using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private const float spawnRange = 9f;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        
        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }
}