using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die(){
        GameObject.FindWithTag("GameManager").GetComponent<GameController>().addToEnemies(-1);
        Destroy(gameObject);
    }
}
