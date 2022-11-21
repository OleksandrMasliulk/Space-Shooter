using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _destroyVFX;

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
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        if (_destroyVFX != null)
            Instantiate(_destroyVFX, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
