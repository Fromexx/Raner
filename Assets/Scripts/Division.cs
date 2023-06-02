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
        value = Random.Range(1, 10);
        if (army.armyCount % value != 0)
        {
            while (army.armyCount % value != 0)
            {
                value = Random.Range(1, 10);
            }
        }
        army.armyCount /= value;
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.armyCount /= value;
        }
    }
}
