using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int Level = 1;
    public float Experience = 0;
    public float ExperienceNeeded = 15;
    private PlayerMovement PlayerMovement;
    private PlayerShoot PlayerShoot;
    public float expPercentage = 0;

    [SerializeField]
    private UnityEngine.UI.Image _experienceBarForegroundImage;

    [SerializeField]
    private TMP_Text _LevelText;

    public void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerShoot = GetComponent<PlayerShoot>();
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
            UpdateLevelText();
            UpdateExpBar();
            PlayerMovement.speed += 1;
            PlayerShoot.bulletDamage += 1;
            PlayerShoot.timeBetweenShots -= 0.1f;
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


