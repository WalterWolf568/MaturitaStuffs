using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;


    [SerializeField]
    private float timeBetweenShots;

    public void Start()
    {
        StartCoroutine(ShootBullet());
    }
    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().friendly = false;
        bullet.GetComponent<Bullet>().bulletDamage = 10;
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        Renderer renderer = bullet.GetComponentInChildren<SpriteRenderer>();
        renderer.material.color = Color.red;
        rigidbody.transform.Rotate(0, 0, 90f);
        rigidbody.velocity = bulletSpeed * transform.right;
    }

    private IEnumerator ShootBullet()
    {
        while (true) 
        {
            FireBullet();
            yield return new WaitForSeconds(timeBetweenShots); 
        }
    }
}
