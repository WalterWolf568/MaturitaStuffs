using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    public AudioClip bgMusic;
    public AudioClip buttonSFX;
    public AudioClip shootSFX;


    private void Start()
    {
        musicSource.clip = bgMusic;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void OnButtonClick()
    {
        sfxSource.clip = buttonSFX;
        sfxSource.Play();
    }

    public void OnPlayerShoot()
    {
        sfxSource.clip = shootSFX;
        sfxSource.Play();
    }
}
