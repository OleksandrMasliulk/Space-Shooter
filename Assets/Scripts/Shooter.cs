using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Transform _muzzleVFX;

    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _projectileMoveSpeed;
    [SerializeField] private float _projectileLifetime;

    [Header("Shooting behaviour")]
    [SerializeField] private float _baseFireRate;
    [SerializeField] private float _fireRateVariance;
    [SerializeField] private float _minFireRate;

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
            yield return new WaitForSeconds(GetRandomFireRate());
        }
    }

    private void SpawnProjectile()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
        if (projectile.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
            rigidbody2D.velocity = _projectileSpawnPoint.transform.up * _projectileMoveSpeed;

        if (_muzzleVFX != null)
            Instantiate(_muzzleVFX, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation, _projectileSpawnPoint);

        Destroy(projectile, _projectileLifetime);
    }

    public void SetIsIfring(bool newValue)
    {
        _isFiring = newValue;
    }

    private float GetRandomFireRate()
    {
        float fireRate = Random.Range(_baseFireRate - _fireRateVariance, _baseFireRate + _fireRateVariance);
        return Mathf.Clamp(fireRate, _minFireRate, float.MaxValue);
    }
}