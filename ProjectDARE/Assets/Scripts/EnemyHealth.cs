using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die(){
        if (_isAlive){
            GameObject.FindWithTag("GameManager").GetComponent<GameController>().addToEnemies(-1);
            Destroy(gameObject);
        }
        _isAlive = false;
    }
}
