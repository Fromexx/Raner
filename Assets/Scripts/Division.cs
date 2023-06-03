using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Division : MonoBehaviour
{
    int value;
    Army army;


    private void Start()
    {              
        army = FindObjectOfType<Army>();
        value = Random.Range(2, 5);
        if (army.armyCount % value != 0)
        {
            while (army.armyCount % value != 0)
            {
                value = Random.Range(2, 5);
            }
        }
        army.OnArmyCountChanged(army.armyCount / value);
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.OnArmyCountChanged(army.armyCount / value);
        }
    }
}
