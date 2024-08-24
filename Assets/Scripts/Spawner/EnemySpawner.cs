using UnityEngine;

/// <summary>
/// Script that generate enemies on box border
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public Vector2 boxSize = Vector2.one;
    public EnemyWaveSpawnerData waveSpawnerData;

    private float currentSpawnInterval = 0f;
    private float currentWaveCountdown = 0f;

    public Transform playerTransform;
    [SerializeField]
    private Transform followUp;

    private int currentWaveIndex = 0;

    private void Start()
    {
        if (waveSpawnerData.waves.Count > 0)
        {
            currentSpawnInterval = waveSpawnerData.waves[currentWaveIndex].spawnInterval;
            currentWaveCountdown = waveSpawnerData.timeBetweenWaves;
        }
        else
        {
            Debug.LogWarning("No waves in waveSpawnerData to spawn");
        }

    }

    private void FixedUpdate()
    {
        if (currentSpawnInterval < 0f)
        {
            SpawnEnemy();
        }
        else
        {
            currentSpawnInterval -= Time.fixedDeltaTime;
        }

        if (currentWaveCountdown > 0f)
        {
            currentWaveCountdown -= Time.fixedDeltaTime;
        }
        else
        {
            ChangeToNextWave();
        }

        if (followUp != null)
        {
            transform.position = followUp.position;
        }
    }

    public void SpawnEnemy()
    {
        if (waveSpawnerData.waves[currentWaveIndex].enemiesToSpawn.Count > 0)
        {
            bool spawnOnTopBottomBorder = Random.Range(0, 2) == 1;

            float x, y;
            if (spawnOnTopBottomBorder)
            {
                x = Random.Range(-boxSize.x, boxSize.x);
                y = Random.Range(0, 2) == 1 ? boxSize.y : -boxSize.y;
            }
            else
            {
                x = Random.Range(0, 2) == 1 ? boxSize.x : -boxSize.x;
                y = Random.Range(-boxSize.y, boxSize.y);
            }

            int posibleEnemiesCount = waveSpawnerData.waves[currentWaveIndex].enemiesToSpawn.Count;
            GameObject enemyToSpawn = waveSpawnerData.waves[currentWaveIndex].enemiesToSpawn[Random.Range(0, posibleEnemiesCount)];

            Enemy newEnemy = Instantiate(enemyToSpawn, new Vector2(transform.position.x + x, transform.position.y + y), Quaternion.identity).GetComponent<Enemy>();
            newEnemy.PlayerTransform = playerTransform;

            currentSpawnInterval = waveSpawnerData.waves[currentWaveIndex].spawnInterval;
        }
    }

    public void ChangeToNextWave()
    {
        currentWaveIndex++;
        if (currentWaveIndex < waveSpawnerData.waves.Count)
        {
            currentWaveCountdown = waveSpawnerData.timeBetweenWaves;
        }
        else
        {
            enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, boxSize * 2);
    }
}
