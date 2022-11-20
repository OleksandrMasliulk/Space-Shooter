using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    public int Damage => _damage;

    private void Hit()
    {
        Destroy(this.gameObject);
    }
}
