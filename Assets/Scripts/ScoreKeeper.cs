using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper Instance;
    private int _score = 0;

    public int Score => _score;

    private void Awake() 
    {
        HandleSingleton();
    }

    private void HandleSingleton()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

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
