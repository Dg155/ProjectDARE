using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private List<GameObject> walls;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SelectExtraDamage()
    {
        shootingPoint.GetComponent<FireBullets>().extraDamage += 10;
    }

    public void SelectDecreaseFireRate()
    {
        shootingPoint.GetComponent<FireBullets>().decreasedFireRate -= 0.1f;
    }

    public void SelectExtraWallHealth()
    {
        for (int i = 0; i < 4; ++i)
        {
            walls[i].GetComponent<Health>().AddExtraHealth();
        }
    }

}
