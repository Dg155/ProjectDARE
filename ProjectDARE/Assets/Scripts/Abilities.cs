using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private List<GameObject> walls;

    // Adds 5 damage to each bullet, giving a total extra 25 damage
    public void SelectExtraDamage()
    {
        shootingPoint.GetComponent<FireBullets>().extraDamage += 5;
    }

    // Decrease fire rate by 0.1 seconds
    public void SelectDecreaseFireRate()
    {
        shootingPoint.GetComponent<FireBullets>().decreasedFireRate -= 0.1f;
    }

    // Give each wall an extra 25 health, effectively giving each wall one extra hit
    public void SelectExtraWallHealth()
    {
        for (int i = 0; i < 4; ++i)
        {
            walls[i].GetComponent<Health>().AddExtraHealth(25);
        }
    }

}
