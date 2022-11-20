using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private List<WaveConfigSO> _waveConfigs;
    [SerializeField] private float _timeBetweenWaves;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        foreach(WaveConfigSO waveConfig in _waveConfigs)
        {
            yield return StartCoroutine(SpawnEnemies(waveConfig));

            if (waveConfig == _waveConfigs[_waveConfigs.Count - 1])
                yield return null;
            else
                yield return new WaitForSeconds(_timeBetweenWaves);
        }
        Debug.Log("Done spawning enemy waves!");
    }

    IEnumerator SpawnEnemies(WaveConfigSO waveConfig)
    {
        for (int i = 0; i < waveConfig.EnemyCount; i++)
        {
            GameObject enemyGO = Instantiate(waveConfig.GetEnemyPrefab(0),
                                            waveConfig.GetFirstWaypoint().position,
                                            Quaternion.identity,
                                            _spawnParent);
            Pathfinder enemyPathfinder = enemyGO.GetComponent<Pathfinder>();
            enemyPathfinder.Construct(waveConfig);

            if (i == waveConfig.EnemyCount - 1)
                yield return null;
            else
                yield return new WaitForSeconds(waveConfig.GetSpawnTime());
        }
    }
}