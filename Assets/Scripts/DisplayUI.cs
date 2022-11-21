using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayUI : MonoBehaviour
{
    [Header("Score")]
    private ScoreKeeper _scoreKeeper;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Header("Health")]
    [SerializeField] private UnitHealth _playerHealth;
    [SerializeField] private Slider _healthSlider;

    private void Awake() 
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update() 
    {
        UpdateScore(_scoreKeeper.Score);
        UpdateHealthSlider(_playerHealth.CurrentHealthNormalized);
    }

    public void UpdateScore(int newValue)
    {
        _scoreText.text = newValue.ToString("000000000");
    }

    public void UpdateHealthSlider(float healthNormalized)
    {
        _healthSlider.value = healthNormalized;
    }
}
