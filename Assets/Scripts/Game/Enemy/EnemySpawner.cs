
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
    private float frequencyOfSpawn;

    [SerializeField]
    private char Spawner;

    private Vector2 _spawnPosition;
    private float _random;
    private float _timeUntilSpawn;

    public bool isSpawning = false;

    public HealthController _healthController;
    public WaveController _waveController;
    private int i = 0;

    private void Awake()
    {
        SetTimeUntilSpawn();
        _healthController = FindObjectOfType<HealthController>();
        _waveController = FindObjectOfType<WaveController>();
        _healthController.OnDied.AddListener(StopSpawning);
    }

    private void Update()
    {
       if(isSpawning == false)
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
                Instantiate(_enemyPrefab, _spawnPosition, transform.rotation);
                SetTimeUntilSpawn();
                i++;
            }
        }
    }
    private void SetTimeUntilSpawn()
    {
        _random = Random.Range((float)-0.5, (float)0.5);
        _timeUntilSpawn = frequencyOfSpawn + _random;
    }
    private void WavePause()
    {
        StartCoroutine(WaveWaitCoroutine());
    }
    private void SetSpawnPosition()
    {
        _random = Random.Range(1, 4);
        _spawnPosition.x = transform.position.x + 14;
       
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
    private IEnumerator WaveWaitCoroutine()
    {

            yield return new WaitForSeconds(10);

    }

    private void StopSpawning()
    {
        gameObject.SetActive(false);
    }
}
