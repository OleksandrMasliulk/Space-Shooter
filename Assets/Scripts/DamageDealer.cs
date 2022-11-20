using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    public int Damage => _damage;

    public void Hit()
    {
        Destroy(this.gameObject);
    }
}
