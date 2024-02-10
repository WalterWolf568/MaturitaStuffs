using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    public int Score {  get; private set; }

    public void AddScore(int amount)
    {
        
        Score += amount;
        OnScoreChanged.Invoke();
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        if (Score > PlayerPrefs.GetInt("Highscore")) 
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }
    }
}
