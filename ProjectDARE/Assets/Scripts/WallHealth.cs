using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallHealth : Health
{
    private Color tempcolor;

    protected override void Die(){
        tempcolor = this.GetComponent<Tilemap>().color;
        tempcolor.a = .5f;
        this.GetComponent<Tilemap>().color = tempcolor;
        gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        Debug.Log("Wall is destoryed!");
    }
}
