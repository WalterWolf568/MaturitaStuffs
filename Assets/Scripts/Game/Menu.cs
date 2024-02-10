using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro Namespace

public class Menu : MonoBehaviour
{
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;


    [SerializeField]
    public TMP_Text Highscore;

    public void Start()
    {

        Highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>(); 

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].ToString();
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log(Screen.currentResolution);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleFullscreen(bool togFullscreen)
    {
        Screen.fullScreen = togFullscreen;
    }


}