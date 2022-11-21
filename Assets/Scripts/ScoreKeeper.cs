using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score = 0;

    public int Score => _score;

    public void ModifyScore(int value)
    {
        _score += value;
        Mathf.Clamp(_score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
