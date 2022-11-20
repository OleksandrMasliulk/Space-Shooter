using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            TakeDamage(damageDealer.Damage);
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
        Destroy(this.gameObject);
    }
}
