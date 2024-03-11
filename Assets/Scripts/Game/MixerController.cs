using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    public void Start()
    {
        Debug.Log("Checking PlayerPrefs for audio settings...");

        if (PlayerPrefs.HasKey("masterVolume"))
        {
            audioMixer.SetFloat("masterVolume", Mathf.Log10(PlayerPrefs.GetFloat("masterVolume")) * 20f);
            masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");

        }
        else { Debug.Log("PlayerPrefs doesnt have masterVolume"); }
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            audioMixer.SetFloat("musicVolume", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume")) * 20f);
            musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else { Debug.Log("PlayerPrefs doesnt have musicVolume"); }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            audioMixer.SetFloat("sfxVolume", Mathf.Log10(PlayerPrefs.GetFloat("sfxVolume")) * 20f);
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else { Debug.Log("PlayerPrefs doesnt have sfxVolume"); }
    }

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
        Debug.Log("Setting Master Volume");
        PlayerPrefs.SetFloat("masterVolume", level);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
        Debug.Log("Setting Music Volume");
        PlayerPrefs.SetFloat("musicVolume", level);
    }
    public void SetSfxVolume(float level)
    {
        audioMixer.SetFloat("sfxVolume", Mathf.Log10(level) * 20f);
        Debug.Log("Setting SFX Volume");
        PlayerPrefs.SetFloat("sfxVolume", level);
    }
}
