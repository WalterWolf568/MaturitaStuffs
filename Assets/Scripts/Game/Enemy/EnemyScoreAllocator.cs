using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int _killScore; //customizable for each type of enemy

    [SerializeField]
    private int _killExperience;

    private ScoreController _scoreController;
    private LevelController _levelController;


    private void Awake()
    {
        _scoreController = FindObjectOfType<ScoreController>();//the player has the ScoreController
        _levelController = FindObjectOfType<LevelController>();
    }
    public void AllocateScore()
    {
        _scoreController.AddScore(_killScore); // method inside ScoreController
    }
    public void AllocateExperience()
    {
        _levelController.AddExperience(_killExperience);
    }
}
