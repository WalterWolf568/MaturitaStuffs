using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonController : MonoBehaviour
{
    [SerializeField] private Button DifficultyButton;

    public void Start()
    {

        DifficultyButton.onClick.AddListener(ToggleState);
        DifficultyButton.onClick.AddListener(UpdateButtonText);
        UpdateButtonText();
    }
    public void UpdateButtonText()
    {
        switch (DifficultyController.Instance.Difficulty)
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
    public void ToggleState()
    {
        DifficultyController.Instance.Difficulty = (DifficultyController.Instance.Difficulty + 1) % 3;

        int Difficulty = DifficultyController.Instance.Difficulty;
        Debug.Log("Difficulty: "+Difficulty);
        Debug.Log($"Difficulty Damage x  {DifficultyController.Instance.DifficultyDamage[Difficulty]}");
        Debug.Log($"Difficulty Health x  {DifficultyController.Instance.DifficultyHealth[Difficulty]}");
        Debug.Log($"Difficulty Fire Rate x  {DifficultyController.Instance.DifficultyFireRate[Difficulty]}");
        Debug.Log($"Difficulty Speed x  {DifficultyController.Instance.DifficultySpeed[Difficulty]}");
    }
}
