using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public int Level = 1;
    public float Experience = 0;
    public float ExperienceNeeded = 15;
    private PlayerMovement PlayerMovement;
    private PlayerShoot PlayerShoot;
    private LevelUpController LevelUpController;
    [SerializeField]
    private Canvas _Canvas;
    public float expPercentage = 0;

    [SerializeField]
    private UnityEngine.UI.Image _experienceBarForegroundImage;

    [SerializeField]
    private TMP_Text _LevelText;



    public void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerShoot = GetComponent<PlayerShoot>();
        LevelUpController = _Canvas.GetComponentInChildren<LevelUpController>();
    }

    public void AddExperience(int amount)
    {
        Experience += amount;

        if (ExperienceNeeded < Experience) {
            Level++;
            Debug.Log($"Experience before lvlup:{Experience}");
            Experience -= ExperienceNeeded;
            Debug.Log($"Experience after lvlup:{Experience}");
            Debug.Log($"Level up: {Level}");
            ExperienceNeeded += 5;
            expPercentage = Experience / ExperienceNeeded;
            LevelUpController.LevelUp();

    
            UpdateLevelText();
            UpdateExpBar();

        }
        else
        {
            expPercentage = Experience / ExperienceNeeded;
            UpdateExpBar();
        }

    }

    private void UpdateLevelText()
    {
        _LevelText.text = $"Level: {Level}";
    }

    private void UpdateExpBar()
    {
        Debug.Log(expPercentage);
        _experienceBarForegroundImage.fillAmount = expPercentage;
    }
}


