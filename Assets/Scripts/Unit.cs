using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum UnitType {enemy, player};

    public UnitType unitType;
    Army army;
    EnemyArmy enemyArmy;
    bool right;

    private void Start()
    {
        army = FindObjectOfType<Army>();
        enemyArmy = FindObjectOfType<EnemyArmy>();
    }

    private void Update()
    {
        if (right == false)
        {
            if (unitType == UnitType.enemy)
            {
                while (right == false)
                {
                    transform.position = new Vector3(Random.Range(-enemyArmy.radius, enemyArmy.radius), 0f, Random.Range(-enemyArmy.radius, enemyArmy.radius));
                }
            }
            else
            {
                while (right == false)
                {
                    transform.position = new Vector3(Random.Range(-army.radius, army.radius), 0f, Random.Range(-army.radius, army.radius));
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (unitType == UnitType.enemy)
        {
            if (collision.collider.CompareTag("EnemyArmy"))
            {
                right = false;
            }
            else
            {
                right = true;
            }
        }
        else
        {
            if (collision.collider.CompareTag("Army"))
            {
                right = false;
            }
            else
            {
                right = true;
            }
        }
    }
}
