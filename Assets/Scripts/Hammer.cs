using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int damage;
    public float radius;
    Army army;

    private void Start()
    {
        army = FindObjectOfType<Army>();
    }

    public void Attack()
    {
        Collider[] units = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider unit in units)
        {
            if (unit.CompareTag("Army"))
            {
                army.ArmyCount -= damage;
                break;
            }
        }
    }
}
