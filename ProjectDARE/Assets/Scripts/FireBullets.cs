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
    [SerializeField] private float bulletCount = 5f;
    [SerializeField] private float bulletSpread = 0.1f;
    [SerializeField] private float fireRate = 0.5f;
    private float elapsedCooldown = 0f;
    public int extraDamage = 0;
    public float decreasedFireRate = 0f;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - elapsedCooldown >= fireRate - decreasedFireRate|| elapsedCooldown == 0f)
            {
                Shoot();
                elapsedCooldown = Time.time;
            }
        }
    }

    void Shoot()
    {
        List<GameObject> bullets = new List<GameObject>();
        for (int i = 0; i < bulletCount; ++i)
        {
            Quaternion bulletRotation = shootingPoint.rotation;
            bulletRotation.x += Random.Range(-bulletSpread, bulletSpread);
            bulletRotation.y += Random.Range(-bulletSpread, bulletSpread);
            GameObject BulletInstance = Instantiate(bullet, shootingPoint.position, bulletRotation);
            // For when the extra damage ability is picked
            BulletInstance.GetComponent<BulletBehavior>().bulletDamage += extraDamage;
            BulletInstance.GetComponent<Rigidbody2D>().AddForce(BulletInstance.transform.right * bulletSpeed);
            bullets.Add(BulletInstance);
        }
        gunAnimator.SetTrigger("Shoot");
        
        // delete the bullets after 3 seconds if they have not collided with anything
        for (int i = 0; i < bulletCount; ++i)
        {
            Destroy(bullets[i], 1.5f);
        }
    }
}
