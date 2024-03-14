using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject wheelPrefab;

    [SerializeField]
    private float bulletSpeed;


    public void Start()
    {
        bulletSpeed = bulletSpeed * DifficultyController.Instance.DifficultyDamage[DifficultyController.Instance.Difficulty];
    }
    public void FireBullet()
    {
        GameObject bullet = Instantiate(wheelPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BossBullet>().bulletDamage = 20;
        rigidbody.transform.Rotate(0, 0, 90f);
        rigidbody.velocity = bulletSpeed * transform.right;
        Destroy(bullet, 7f);
    }

}
