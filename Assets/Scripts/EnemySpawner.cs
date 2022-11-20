using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private WaveConfigSO _currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _currentWave.EnemyCount; i++)
        {
            GameObject enemyGO = Instantiate(_currentWave.GetEnemyPrefab(0),
                                            _currentWave.GetFirstWaypoint().position,
                                            Quaternion.identity,
                                            _spawnParent);
            Pathfinder enemyPathfinder = enemyGO.GetComponent<Pathfinder>();
            enemyPathfinder.Construct(_currentWave);
        }
    }
}