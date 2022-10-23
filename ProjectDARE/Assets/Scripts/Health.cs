using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Health script that is applicable to the player and enemies
public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHealth = 100;
    [SerializeField] protected bool _printToConsole = true;
    protected int _currentHealth;
    protected bool _isAlive;

    void Start()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
    }

    public virtual void TakeDamage(int damageTaken)
    {
        _currentHealth -= damageTaken;
        if (_printToConsole is true) {Debug.LogFormat("{0} took {1} damage", gameObject.tag, damageTaken);}

        if (_currentHealth <= 0)
        {
            _isAlive = false;
            Die();
        }
    }

    public void HealHealth(int healthHealed)
    {
        _currentHealth += healthHealed;
        if (_printToConsole is true) {Debug.LogFormat("{0} healed {1} health", gameObject.tag, healthHealed);}

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
            if (_printToConsole is true) {Debug.LogFormat("{0} is at full health", gameObject.tag);}
        }
    }

    public void Kill()
    {
        TakeDamage(_currentHealth);
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public bool CheckIsAlive()
    {
        return _isAlive;
    }

    protected virtual void Die(){}

}
