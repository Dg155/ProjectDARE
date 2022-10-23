using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    // fire rate variable is equal to the cooldown time in seconds between shots
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 1000f;
    [SerializeField] private float fireRate = 0.5f;
    private float elapsedCooldown = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - elapsedCooldown >= fireRate || elapsedCooldown == 0f)
            {
                Shoot();
                elapsedCooldown = Time.time;
            }
        }
    }

    void Shoot()
    {
        GameObject BulletInstance = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        BulletInstance.GetComponent<Rigidbody2D>().AddForce(BulletInstance.transform.right * bulletSpeed);
        gunAnimator.SetTrigger("Shoot");
        Destroy(BulletInstance, 3);
    }
}
