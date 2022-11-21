using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _destroyVFX;
    [SerializeField] private bool _applyCameraShake;

    private PlayerCameraShake _playerCameraShake;

    private void Awake() 
    {
        _playerCameraShake = GetComponent<PlayerCameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            TakeDamage(damageDealer.Damage);
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        if (_applyCameraShake && _playerCameraShake != null)
            _playerCameraShake.InvokeImpactShake();

        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        if (_applyCameraShake && _playerCameraShake != null)
            _playerCameraShake.InvokeDeathShake();

        if (_destroyVFX != null)
            Instantiate(_destroyVFX, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
