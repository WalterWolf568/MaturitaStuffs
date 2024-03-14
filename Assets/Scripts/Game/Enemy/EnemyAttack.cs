using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;
    

    private void Start()
    {
        float multiplier = DifficultyController.Instance.DifficultyDamage[DifficultyController.Instance.Difficulty];
        damageAmount = damageAmount * multiplier;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(damageAmount);
        }
    }
}
