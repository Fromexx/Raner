using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Army : MonoBehaviour
{
    public event Action AllUnitsDied;
    public int ArmyCount => Units.Count;

    public int Damage
    {
        get => _damage;
        set
        {
            if (value < 0) return;
            _damage = value;
        }
    }

    public UnitSpawnAndDelete UnitSpawnAndDelete => _unitSpawnAndDelete;
    
    protected List<GameObject> Units;

    [SerializeField] private UnitSpawnAndDelete _unitSpawnAndDelete;

    private int _damage;

    protected void AddUnits(List<GameObject> units)
    {
        Units.AddRange(units);
    }

    protected void RemoveUnits(List<GameObject> units)
    {
        var firstDeletedUnitIndex = units.FindIndex(x => x == units[0]);
        Units.RemoveRange(firstDeletedUnitIndex, units.Count);
    }

    public void OnUnitsSpawning(int unitsCount)
    {
        var spawnedUnits = _unitSpawnAndDelete.SpawnUnits(unitsCount);
        Units.AddRange(spawnedUnits);
    }

    public void OnUnitsDeleting(int unitsCount)
    {
        _unitSpawnAndDelete.DeleteUnits(unitsCount, ref Units);
        
        if(Units.Count <= 0) AllUnitsDied?.Invoke();
    }
}
