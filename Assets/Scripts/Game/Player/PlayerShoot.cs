using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField] 
    public int bulletDamage = 5;   

    [SerializeField]
    private Transform gunOffset;

    [SerializeField]
    public float timeBetweenShots;

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastTimeFire;

    public bool canShoot = true;
    // Start is called before the first frame update
    [SerializeField]
    GameObject SoundManager;
    
    private SoundController _soundController;

    public void Awake()
    {
        canShoot = true;
        _soundController = SoundManager.GetComponent<SoundController>();
    }
    void Update()
    {
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastTimeFire;

            if(timeSinceLastFire > timeBetweenShots)
            {
                if(canShoot)
                {
                    FireBullet();

                    _lastTimeFire = Time.time;

                    _fireSingle = false;
                }
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation);
        bullet.GetComponent<Bullet>().friendly = true;
        bullet.GetComponent<Bullet>().bulletDamage = bulletDamage;
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.transform.Rotate(0, 0, 90f);
        rigidbody.velocity = bulletSpeed * transform.right;
        _soundController.OnPlayerShoot();

    }
    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }  
}
