using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHealth : Health
{
    protected override void Die(){
        Debug.Log("Game Over!");
    }
}
