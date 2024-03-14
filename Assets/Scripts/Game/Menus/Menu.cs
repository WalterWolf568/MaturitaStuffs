using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro Namespace
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    [SerializeField]
    public TMP_Text Highscore;

    public void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

}