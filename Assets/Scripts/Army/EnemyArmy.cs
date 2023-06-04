using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : Army
{
    public int startUnitsHealth;
    PlayerArmy army;
    float minDistance;
    float maxDistance;

    private void Start()
    {
        ArmyCount = Random.Range(5, 200);
        army = FindObjectOfType<PlayerArmy>();

        _nextSpawnedUnitCircleIndex = 0;
        _nextSpawnedUnitIndex = 0;
        
        SpawnArmy(ArmyCount);
    }

    private void Update()
    {
        float distance = Vector3.Distance(army.transform.position, transform.position);
        
        if (distance < maxDistance)
        {
            if (distance > minDistance)
            {
                //army.transform.position = Vector3.MoveTowards(army.transform.position, transform.position, army.speed * Time.deltaTime);
            }
        }
    }
}
