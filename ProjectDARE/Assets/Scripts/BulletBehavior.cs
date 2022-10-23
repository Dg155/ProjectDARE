using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int bulletDamage = 50;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)   // has a health script if true
        {
            other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        }
        Destroy(Bullet);
    }
}
