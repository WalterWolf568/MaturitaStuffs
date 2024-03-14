using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    private GameObject _Graphics;
    private Rigidbody2D _rigidbody;
    private Vector2 _directionToPlayer;
    private Vector2 _playerPosition;
    private float rotationSpeed = 180000f;
    public bool Bossfight;
    private int position;
    private BossFightController BossFightController;



    BossShoot bossShoot;

    [SerializeField]
    private GameObject SwordWheel;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _Graphics = transform.Find("BossEnemyGraphics").gameObject;
        bossShoot = GetComponentInChildren<BossShoot>();
        BossFightController = FindObjectOfType<BossFightController>();
        if (Bossfight)
        {
            StartCoroutine(BossfightCoroutine());
            StartCoroutine(BossShootCoroutine());
        }

    }

    private void Update()
    {
        SetDirection();
        FlipGraphics();
    }

    private void SetDirection()
    {
        _playerPosition = FindObjectOfType<PlayerMovement>().transform.position;
        _directionToPlayer = _playerPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(_directionToPlayer.y, _directionToPlayer.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);


        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        _rigidbody.SetRotation(rotation);
        _Graphics.transform.localRotation = Quaternion.Inverse(rotation);
    }
    private void FlipGraphics()
    {
        if (_rigidbody.velocity.x > 0)
        {
            _Graphics.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rigidbody.velocity.x < 0)
        {
            _Graphics.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public IEnumerator BossfightCoroutine()
    {
        while (Bossfight)
        {
            SetNextPosition();
            yield return new WaitForSeconds(6f); // Adjust as needed
        }
    }
    public IEnumerator BossShootCoroutine()
    {
        while (Bossfight)
        {
            bossShoot.FireBullet();
            yield return new WaitForSeconds(2f);
        }
    }
    private void SetNextPosition()
    {
        position = (position + 1) % 4;
        transform.position = BossFightController.BossPositions[position];
    }
}