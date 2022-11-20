using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _projectileMoveSpeed;
    [SerializeField] private float _projectileLifetime;
    [SerializeField] private float _timeBetweenShots;

    private bool _isFiring = false;
    private Coroutine _fireCoroutine;

    private void Update() 
    {
        Shoot();
    }

    private void Shoot()
    {
        if (!_isFiring && _fireCoroutine != null)
        {
            StopCoroutine(_fireCoroutine);
            _fireCoroutine = null;

        }
        else if (_isFiring && _fireCoroutine == null)
            _fireCoroutine = StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while(true)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(_timeBetweenShots);
        }
    }

    private void SpawnProjectile()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
        if (projectile.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
            rigidbody2D.velocity = transform.up * _projectileMoveSpeed;

        Destroy(projectile, _projectileLifetime);
    }

    public void SetIsIfring(bool newValue)
    {
        _isFiring = newValue;
    }
}
