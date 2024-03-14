using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    [SerializeField] GameObject BossArena;
    [SerializeField] BossMovementController bossMovementController;

    [SerializeField] GameObject BossEnemy;

    public Vector3[] BossPositions;
    public bool isBossFightInProgress = false;

    void Start()
    {
    }

    public void StartBossFight()
    {
        if (!isBossFightInProgress)
        {
            isBossFightInProgress = true;
            SpawnArena();
           
        }
    }
    public void SpawnArena()
    {
        BossPositions = new Vector3[4];
        BossPositions[0] = new Vector3(transform.position.x + 13, transform.position.y, transform.position.z);
        BossPositions[1] = new Vector3(transform.position.x - 13, transform.position.y, transform.position.z);
        BossPositions[2] = new Vector3(transform.position.x, transform.position.y + 13, transform.position.z);
        BossPositions[3] = new Vector3(transform.position.x, transform.position.y - 13, transform.position.z);
        Instantiate(BossArena, transform.position, Quaternion.identity);
        GameObject Boss = Instantiate(BossEnemy, BossPositions[0], Quaternion.identity);
        bossMovementController = Boss.GetComponent<BossMovementController>();
        bossMovementController.Bossfight = true;

    }

    public void StopBossFight()
    {
        bossMovementController.Bossfight = false;
        isBossFightInProgress = false;
    }


}