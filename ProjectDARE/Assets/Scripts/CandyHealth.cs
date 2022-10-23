using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHealth : Health
{

    [SerializeField] private Sprite oneCandyEaten;
    [SerializeField] private Sprite twoCandyEaten;
    [SerializeField] private Sprite threeCandyEaten;

    public override void TakeDamage(int damageTaken)
    {
        _currentHealth -= damageTaken;
        if (_printToConsole is true) {Debug.LogFormat("{0} took {1} damage", gameObject.tag, damageTaken);}

        if (_currentHealth <= 0)
        {
            _isAlive = false;
            Die();
        }

        if (_currentHealth == 3) {this.GetComponent<SpriteRenderer>().sprite = oneCandyEaten;}
        if (_currentHealth == 2) {this.GetComponent<SpriteRenderer>().sprite = twoCandyEaten;}
        if (_currentHealth == 1) {this.GetComponent<SpriteRenderer>().sprite = threeCandyEaten;}
    }

    protected override void Die(){
        Debug.Log("Game Over!");
    }
}
