
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
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

    public HealthController _healthController;

    private void Awake()
    {
        SetTimeUntilSpawn();
        _healthController = FindObjectOfType<HealthController>();
        _healthController.OnDied.AddListener(StopSpawning);
    }

    private void Update()
    {
        int chance = Random.Range(1, 11);
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            /*  if (Spawner == 'a' || Spawner == 'c')
              {
                  _random = Random.Range(-12, 12);
                  _spawnPosition = transform.position;
                  _spawnPosition.x = _random;
              }
              else if (Spawner == 'b' || Spawner == 'd')
              {
                  _random = Random.Range(-7, 7);
                  _spawnPosition = transform.position;
                  _spawnPosition.y = _random;
              }
              else
              {
                  _spawnPosition = transform.position;
              }*/
            _spawnPosition = transform.position;
            if (chance == 0 ||  chance == 1)
            {
                Instantiate(_shooterEnemyPrefab, _spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(_enemyPrefab, _spawnPosition, Quaternion.identity);
            }
        SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _random = Random.Range((float)-0.5, (float)0.5);
        _timeUntilSpawn = frequencyOfSpawn + _random;
    }

    private void StopSpawning()
    {
        gameObject.SetActive(false);
    }
}
