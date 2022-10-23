using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    bool facingRight;
    Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Render();
    }

    protected virtual void Render()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = targetPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(targetPos.x - this.transform.parent.position.x > 0 && !facingRight || targetPos.x - this.transform.parent.position.x < 0 && facingRight)
        {
            flip();
        }
    }

    private void flip(){
        if (facingRight){
            this.transform.localScale = new Vector3(1,-1,1);
            facingRight = false;
        }
        else{
            this.transform.localScale = new Vector3(-1,1,1);
            facingRight = true;
        }
    }
}
