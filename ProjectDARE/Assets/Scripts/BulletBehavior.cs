using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    public int bulletDamage = 50;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)   // has a health script if true
        {
            if (other.gameObject.tag != "Wall")
            {
                other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            }
        }

        if (other.gameObject.tag != "Bullet")
        {
            Destroy(Bullet);
        }
    }
}
