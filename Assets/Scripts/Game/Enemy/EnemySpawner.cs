
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _shooterEnemyPrefab;

    [SerializeField]
    private float WaveTimeLength = 10;

    [SerializeField]
    private char Spawner;

    private Vector2 _spawnPosition;
    private float _random;
    private float _timeUntilSpawn;

    private float frequencyOfSpawn = 0;

    public bool isSpawning = false;
    public bool isBossFight = false;


    public HealthController _healthController;
    public WaveController _waveController;
    public BossFightController _bossFightController;
    private int i = 0;

    private void Awake()
    {
        SetTimeUntilSpawn();
        _bossFightController = FindObjectOfType<BossFightController>();
        _healthController = FindObjectOfType<HealthController>();
        _waveController = FindObjectOfType<WaveController>();
        _healthController.OnDied.AddListener(StopSpawning);
    }

    private void Update()
    {
        isBossFight = _bossFightController.isBossFightInProgress;
        if(isBossFight)
        {

        }
        else
        {
            if (isSpawning == false)
            {
                _waveController.CreateWave();
                WavePause();
                isSpawning = true;
            }
            else
            {
                _timeUntilSpawn -= Time.deltaTime;
                if (_timeUntilSpawn <= 0)
                {
                    SetSpawnPosition();
                    if (i >= _waveController.WaveSize)
                    {
                        i = 0;
                        isSpawning = false;
                    }
                    _enemyPrefab = _waveController.Wave[i];
                    GameObject Enemy = Instantiate(_enemyPrefab, _spawnPosition, transform.rotation);
                    Enemy.GetComponentInChildren<HealthController>().AddMaxHealth(_waveController.ExtraHealth);
                    SetTimeUntilSpawn();
                    i++;
                }
            }
        }
       
    }
    private void SetTimeUntilSpawn()
    {
        if (_waveController != null && _waveController.WaveSize > 0)
        {
            frequencyOfSpawn = (WaveTimeLength - 2) / _waveController.WaveSize;
            _timeUntilSpawn = frequencyOfSpawn;
        }
        else
        {
            _timeUntilSpawn = frequencyOfSpawn;
            Debug.Log("_waveController.WaveSize je null nebo neco takovyho");
        }
    }
    private void WavePause()
    {
        StartCoroutine(WaveWaitCoroutine(WaveTimeLength));
    }
    private void SetSpawnPosition()
    {
        _random = Random.Range(1, 5);
        switch(_random)
        {
            
            case 1:
                _spawnPosition.x = transform.position.x + Random.Range(10, 15);
                _spawnPosition.y = transform.position.y + Random.Range(10, 15);
                break;
            case 2:
                _spawnPosition.x = transform.position.x + Random.Range(-10, -15);
                _spawnPosition.y = transform.position.y + Random.Range(10, 15);
                break;
            case 3:
                _spawnPosition.x = transform.position.x + Random.Range(10, 15);
                _spawnPosition.y = transform.position.y + Random.Range(-10, -15);
                break;
            case 4:
                _spawnPosition.x = transform.position.x + Random.Range(-10, -15);
                _spawnPosition.y = transform.position.y + Random.Range(-10, -15);
                break;
            

    }
       
}
    private IEnumerator WaveWaitCoroutine(float TimeToWait)
    {

            yield return new WaitForSeconds(TimeToWait);

    }

    private void StopSpawning()
    {
        gameObject.SetActive(false);
    }
}
