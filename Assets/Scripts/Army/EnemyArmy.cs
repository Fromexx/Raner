using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : Army
{   

    private void Start()
    {
        ArmyCount = Random.Range(5, 200);      

        _nextSpawnedUnitCircleIndex = 0;
        _nextSpawnedUnitIndex = 0;
        
        SpawnArmy(ArmyCount);
    }

    
}
