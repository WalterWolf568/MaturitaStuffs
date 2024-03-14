using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    private BossFightController BossFightController;
    private GameObject Arena;
    private WaveController waveController;

    void Start()
    {
        BossFightController = FindAnyObjectByType<BossFightController>();
        Arena = transform.Find("BossArena").gameObject;
        waveController = FindAnyObjectByType<WaveController>();

    }
    public void EndBossFight()
    {
        BossFightController.StopBossFight();
        waveController.WaveNumber++;
        Destroy(gameObject, 1f);
        Destroy(Arena, 0f);
    }

}
