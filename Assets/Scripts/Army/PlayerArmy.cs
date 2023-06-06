using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmy : Army
{
    public float speed;
    Army army;    

    private void Start()
    {
        army = GetComponent<EnemyArmy>();
        SpawnArmy(ArmyCount);
    }

    private void Update()
    {
        float distance = Vector3.Distance(army.transform.position, transform.position);
    }
}
