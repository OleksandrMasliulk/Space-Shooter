using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private Transform _pathPrefab;
    [SerializeField] private float _movementSpeed;

    public float MovementSpeed => _movementSpeed;
    public int EnemyCount => _enemyPrefabs.Count;

    public Transform GetFirstWaypoint()
    {
        if (_pathPrefab.childCount == 0)
            throw new System.Exception("Path has no waypoints!");

        return _pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        if (_pathPrefab.childCount == 0)
            throw new System.Exception("Path has no waypoints!");

        List<Transform> waypoints = new List<Transform>();
        foreach(Transform waypoint in _pathPrefab)
            waypoints.Add(waypoint);

        return waypoints;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        if (index < 0 || index > _enemyPrefabs.Count - 1)
            throw new System.Exception("Index of an enemy prefab is out of bounds!");
        
        return _enemyPrefabs[index];
    }
}
