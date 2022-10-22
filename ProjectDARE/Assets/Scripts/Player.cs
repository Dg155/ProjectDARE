using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal, vertical;
    protected bool facingRight;
    [SerializeField]
    private float playerSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Render();
        Fire();
    }

    protected void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed);
    }

    protected void Render()
    {    
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x - this.transform.position.x > 0 && !facingRight || mousePos.x - this.transform.position.x < 0 && facingRight)
        {
            flip();
        }
    }

    protected void flip()
    {
        if (facingRight)
        {
            this.transform.localScale = new Vector3(-1,1,1);
            facingRight = false;
        }
        else
        {
            this.transform.localScale = new Vector3(1,1,1);
            facingRight = true;
        }
    }

    protected void Fire()
    {
        if (Input.GetMouseButton(0)){
            Debug.Log("Fire");
        }
    }
}
