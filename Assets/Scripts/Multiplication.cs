using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour
{
    int value;
    Army army;


    private void Start()
    {
        value = Random.Range(2, 5);       
        army = FindObjectOfType<Army>();
        army.OnArmyCountChanged(army.ArmyCount * value);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.OnArmyCountChanged(army.ArmyCount * value);
        }
    }
}
