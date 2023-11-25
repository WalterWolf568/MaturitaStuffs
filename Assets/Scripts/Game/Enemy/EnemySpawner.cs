using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float frequencyOfSpawn;

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

            _timeUntilSpawn -= Time.deltaTime;
            if (_timeUntilSpawn <= 0)
        {
            _spawnPosition = transform.position;
            _random = Random.Range(-30, 30);
            _spawnPosition.x -= _random;
            Instantiate(_enemyPrefab, _spawnPosition , Quaternion.identity);
                SetTimeUntilSpawn();
            }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = frequencyOfSpawn;
    }

    private void StopSpawning()
    {
        gameObject.SetActive(false);
    }
}
