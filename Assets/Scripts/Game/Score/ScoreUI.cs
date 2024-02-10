using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;


    public void UpdateScore(ScoreController scoreController)
    {
        _scoreText.text = $"Score: {scoreController.Score}";
    }
}
