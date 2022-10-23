using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : Health
{
    private Color tempcolor;

    protected override void Die(){
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().material.color.a);
        tempcolor = this.GetComponent<SpriteRenderer>().material.color;
        tempcolor.a = .5f;
        this.GetComponent<SpriteRenderer>().material.color = tempcolor;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Wall is destoryed!");
    }
}
