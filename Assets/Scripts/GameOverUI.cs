using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;

    private ScoreKeeper _scoreKeeper;

    private void Awake() 
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() 
    {
        DisplayFinalScore();
    }

    private void DisplayFinalScore()
    {
        _finalScoreText.text = _scoreKeeper.Score.ToString("000000000");
    }
}
