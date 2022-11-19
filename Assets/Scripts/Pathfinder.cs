using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private WaveConfigSO _waveConfig;
    private List<Transform> _waypoints;
    private int _waypointIndex = 0;

    private void Start() 
    {
        _waypoints = _waveConfig.GetWaypoints();
        transform.position = _waveConfig.GetFirstWaypoint().position;
    }

    private void Update() 
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (_waypointIndex < _waypoints.Count)
        {
            float moveDelta = _waveConfig.MovementSpeed * Time.deltaTime;
            Vector3 targetPosition = _waypoints[_waypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition)
                _waypointIndex++;
        }
        else
            Destroy(this.gameObject);
    }
}
