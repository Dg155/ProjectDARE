using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private AudioClip enemyTakeDamageSFX;
    public int bulletDamage = 20;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)   // has a health script if true
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
                GameObject.FindWithTag("SFXPlayer").GetComponent<AudioSource>().PlayOneShot(enemyTakeDamageSFX);
            }
        }

        if (other.gameObject.tag != "Bullet")
        {
            Destroy(Bullet);
        }
    }
}
