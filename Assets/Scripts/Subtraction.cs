using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtraction : MonoBehaviour
{
    int value;
    Army army;


    private void Start()
    {
        army = FindObjectOfType<Army>();
        value = Random.Range(1, 200);
        if (army.ArmyCount <= value)
        {
            while (army.ArmyCount <= value)
            {
                value = Random.Range(1, 200);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.OnArmyCountChanged(army.ArmyCount - value);
        }
    }
}
