using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    private BossFightController BossFightController;
    void Start()
    {
        BossFightController = FindAnyObjectByType<BossFightController>();
    }
    public void EndBossFight()
    {
        BossFightController.StopBossFight();
        Destroy(gameObject, 1f);
    }

}
