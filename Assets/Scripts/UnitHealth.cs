using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private bool _isPlayer;
    [SerializeField] private int _scoreValue;
    [SerializeField] private int _health;
    private int _maxHealth;

    [Header("FX")]
    [SerializeField] private Transform _destroyVFX;
    [SerializeField] private bool _applyCameraShake;

    public float CurrentHealthNormalized => _health * 1f / _maxHealth;

    private PlayerCameraShake _playerCameraShake;
    private AudioPlayer _audioPlayer;
    private ScoreKeeper _scoreKeeper;


    private void Awake() 
    {
        _playerCameraShake = GetComponent<PlayerCameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _maxHealth = _health;
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

        if (_audioPlayer != null)
            _audioPlayer.PlayHitSFX();

        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        if (_applyCameraShake && _playerCameraShake != null)
            _playerCameraShake.InvokeDeathShake();

        if (_audioPlayer != null)
            _audioPlayer.PlayExplosionSFX();

        if (_destroyVFX != null)
            Instantiate(_destroyVFX, transform.position, Quaternion.identity);

        if (!_isPlayer && _scoreKeeper != null)
            _scoreKeeper.ModifyScore(_scoreValue);

        Destroy(this.gameObject);
    }
}
