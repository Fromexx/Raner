using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour
{
    int value;
    Army army;


    private void Start()
    {
        value = Random.Range(2, 10);       
        army = FindObjectOfType<Army>();
        army.armyCount *= value;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.armyCount *= value;
        }
    }
}
