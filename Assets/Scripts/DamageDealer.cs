using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _impactVFX;

    public int Damage => _damage;

    public void Hit()
    {
        if (_impactVFX != null)
            Instantiate(_impactVFX, transform.position, Quaternion.identity);
            
        Destroy(this.gameObject);
    }
}
