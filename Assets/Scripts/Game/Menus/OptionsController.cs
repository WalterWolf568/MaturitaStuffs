using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    // Start is called before the first frame update
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;



    public void Start()
    {

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

    public void ToggleFullscreen(bool togFullscreen)
    {
        Screen.fullScreen = togFullscreen;
    }
}
