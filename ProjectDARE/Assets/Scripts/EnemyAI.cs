using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 3;
    [SerializeField] private float attack_interval = 1f;
    [SerializeField] private int damageDone = 50;
    [SerializeField] private AudioClip attackHouseSFX;
    [SerializeField] private AudioClip attackCandySFX;
    Rigidbody2D rb;
    private float _time;

    private void Start() {
        _time = attack_interval;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        target = GameObject.FindWithTag("Candy");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed*Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Wall")
        {
            _time += Time.deltaTime;
            while(_time >= attack_interval) {
                other.gameObject.GetComponent<Health>().TakeDamage(damageDone);
                GameObject.FindWithTag("SFXPlayer").GetComponent<AudioSource>().PlayOneShot(attackHouseSFX);
                _time -= attack_interval;
            }
        }
        if (other.gameObject.tag == "Candy")
        {
            _time += Time.deltaTime;
            while(_time >= attack_interval) {
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                GameObject.FindWithTag("SFXPlayer").GetComponent<AudioSource>().PlayOneShot(attackCandySFX);
                _time -= attack_interval;
            }
        }
        if (other.gameObject.tag == "Bullet")
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }

    }
}
