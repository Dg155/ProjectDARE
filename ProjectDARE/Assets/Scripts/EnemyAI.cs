using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject house;
    [SerializeField] private float speed = 3;
    //private float distance;

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, house.transform.position, speed*Time.deltaTime);
    }
}
