using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int waveNumber = 1;
    public GameObject powerUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnEnemyWave(waveNumber);
        Instantiate(powerUp, GenerateSpawnPos(), powerUp.transform.rotation);
    }
    void spawnEnemyWave(int enemiesToWave)
    {
        for (int i = 0; i < enemiesToWave; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float randX = Random.Range(-spawnRange, spawnRange);
        float randZ = Random.Range(-spawnRange, spawnRange);
        Vector3 startPos = new Vector3(randX, 0, randZ);
        return startPos;
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerUp, GenerateSpawnPos(), powerUp.transform.rotation);
        }
    }
}
