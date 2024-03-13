using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    public int Difficulty;
    public double[] DifficultyDamage;
    public double[] DifficultyHealth;
    public float[] DifficultyFireRate;
    public float[] DifficultySpeed;

    [SerializeField] private Button DifficultyButton;


    public void Awake()
    {
        DifficultyDamage = new double[] { 1, 1.5, 2 };
        DifficultyHealth = new double[] { 1, 1.5, 2 };
        DifficultyFireRate = new float[] { 1, 1.5f, 2 };
        DifficultySpeed = new float[] { 1, 1.5f, 2 };

        DifficultyButton.onClick.AddListener(ToggleState);
        UpdateButtonText();
    }

    void ToggleState()
    {
        Difficulty = (Difficulty + 1) % 3;
        UpdateButtonText();
        Debug.Log($"Difficulty Damage x  {DifficultyDamage[Difficulty]}");
        Debug.Log($"Difficulty Health x  {DifficultyHealth[Difficulty]}");
        Debug.Log($"Difficulty Fire Rate x  {DifficultyFireRate[Difficulty]}");
        Debug.Log($"Difficulty Speed x  {DifficultySpeed[Difficulty]}");
    }
    void UpdateButtonText()
    {
        switch(Difficulty)
        {
            case 0:
                DifficultyButton.GetComponentInChildren<TMP_Text>().text = "Easy";
                break;
            case 1:
                DifficultyButton.GetComponentInChildren<TMP_Text>().text = "Hard";
                break;
            case 2:
                DifficultyButton.GetComponentInChildren<TMP_Text>().text = "Silly";
                break;
        }
    }
}
