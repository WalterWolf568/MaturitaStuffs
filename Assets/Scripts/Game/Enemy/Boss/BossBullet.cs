using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        
            if (collision.GetComponent<PlayerShoot>())
            {
                HealthController healthController = collision.GetComponent<HealthController>();
                healthController.TakeDamage(bulletDamage);
                Destroy(gameObject);
            }

        

    }
}
