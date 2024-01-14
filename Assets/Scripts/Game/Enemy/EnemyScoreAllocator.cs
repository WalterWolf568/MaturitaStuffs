using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int _killScore; //customizable for each type of enemy

    private ScoreController _scoreController;


    private void Awake()
    {
        _scoreController = FindObjectOfType<ScoreController>(); //the player has the ScoreController
    }
    public void AllocateScore()
    {
        _scoreController.AddScore(_killScore); // method inside ScoreController
    }
}
