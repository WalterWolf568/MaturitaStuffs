using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool friendly;
    public int bulletDamage;
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (friendly)
        {
            if (collision.GetComponent<Enemy>())
            {
                HealthController healthController = collision.GetComponent<HealthController>();
                healthController.TakeDamage(bulletDamage);
                Destroy(gameObject);

            }
        }
        else
        {
            if (collision.GetComponent<PlayerShoot>())
            {
                HealthController healthController = collision.GetComponent<HealthController>();
                healthController.TakeDamage(bulletDamage);
                Destroy(gameObject);
            }
            
        }
    }
}
