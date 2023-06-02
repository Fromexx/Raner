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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            value = Random.Range(1, 200);
            if (army.armyCount <= value)
            {
                while (army.armyCount <= value)
                {
                    value = Random.Range(1, 200);
                }
            }
            army.armyCount -= value;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.armyCount -= value;
        }
    }
}
