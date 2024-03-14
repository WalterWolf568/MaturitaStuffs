using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    
    public List<GameObject> Wave;

    [SerializeField]
    private GameObject _basicEnemyPrefab;
    [SerializeField]
    private GameObject _shooterEnemyPrefab;
    [SerializeField]
    private GameObject _sprinterEnemyPrefab;

    public BossFightController bossFightController;

    public int WaveSize = 15;
    public int WaveNumber = 0;
    public int ExtraHealth = 0;
    public int UpgradeWave = 5;

    public void Start()
    {
        bossFightController = FindObjectOfType<BossFightController>();
    }
    public void CreateWave()
    {
        Wave.Clear();
        WaveSize = WaveSize + 5;
        WaveNumber++;
        Debug.Log($"WaveNumber: {WaveNumber}");
        Debug.Log($"WaveSize: {WaveSize}");
        if (WaveNumber > UpgradeWave)
        {
            ExtraHealth += 10;
            UpgradeWave += 5;
        }
        if (WaveNumber == 10)
        {
            bossFightController.StartBossFight();
        }
        for (int i = 0; i < WaveSize; i++)
        {

                int random = Random.Range(1, 11);
            if (random == 1 || random == 2)
            {
                Wave.Add(_shooterEnemyPrefab);
            }
            else if (random == 3 || random == 4 || random == 5)
            {
                Wave.Add( _sprinterEnemyPrefab);
            }
            else
            {
                Wave.Add(_basicEnemyPrefab);
            }
            
        }

    }
}
