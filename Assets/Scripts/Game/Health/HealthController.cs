using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maximumHealth;

    
    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public bool _isInvincible;

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;


    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0) 
        {
            return;  
        }
        if (_isInvincible)
        {
            return;
        }
        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth == 0) 
        {
            OnDied.Invoke();

        }
        else
        {
            OnDamaged.Invoke();
        }

     
    }

    public void AddHealth(float addAmount)
    {
        if (currentHealth == maximumHealth)
        {
            return;
        }
        currentHealth += addAmount;
        OnHealthChanged.Invoke();
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }


    }
}
