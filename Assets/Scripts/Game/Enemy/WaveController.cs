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

    public int WaveSize = 15;
    public int WaveNumber = 0;

    public void CreateWave()
    {
        Wave.Clear();
        WaveSize = WaveSize + 5;
        WaveNumber++;
        Debug.Log($"WaveNumber: {WaveNumber}");
        Debug.Log($"WaveSize: {WaveSize}");

        for (int i = 0; i < WaveSize; i++)
        {
            int random = Random.Range(1, 11);
            if (random == 1 || random == 2)
            {
                Wave.Add(_shooterEnemyPrefab);
            }
            else
            {
                Wave.Add(_basicEnemyPrefab);
            }
        }

    }
}
