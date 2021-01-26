using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyToSpawn;

    public float initialSpawnRate;
    public float spawnRateDecay;
    public float minSpawnRate;
    public float spawnDelay;

    [SerializeField]
    private RectTransform spawnArea;

    private float _currentSpawnRate;
    private float _lastSpawn;
    private bool _canSpawn;

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        _currentSpawnRate = initialSpawnRate;
        _lastSpawn = 0;
        StartCoroutine(StartSpawningCoroutine());
    }

    private IEnumerator StartSpawningCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        _canSpawn = true;
    }

    private void Update()
    {
        if(!_canSpawn)
        {
            return;
        }

        if(Time.time - _lastSpawn >= _currentSpawnRate)
        {
            Spawn();
            _currentSpawnRate = Mathf.Max(minSpawnRate, _currentSpawnRate - spawnRateDecay);
            _lastSpawn = Time.time;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(enemyToSpawn, GetSpawnPoint(), Quaternion.identity);

        if (enemy.hasTarget)
        {
            enemy.target = PlayerBuildings.GetRandomBuilding().transform.position;
        }
    }

    private Vector2 GetSpawnPoint()
    {
        float randomX = Random.Range(spawnArea.position.x - spawnArea.rect.width / 2, spawnArea.position.x + spawnArea.rect.width / 2);
        Vector2 spawnpoint = new Vector2(randomX, spawnArea.position.y);
        return spawnpoint;
    }
}
