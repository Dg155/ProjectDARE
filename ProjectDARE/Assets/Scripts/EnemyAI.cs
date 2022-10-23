using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 3;
    [SerializeField] private float attack_interval = 1f;
    [SerializeField] private int damageDone = 50;
    private float _time;

    private void Start() {
        _time = attack_interval;
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
                _time -= attack_interval;
            }
        }
        if (other.gameObject.tag == "Candy")
        {
            _time += Time.deltaTime;
            while(_time >= attack_interval) {
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                _time -= attack_interval;
            }
        }
    }
}
