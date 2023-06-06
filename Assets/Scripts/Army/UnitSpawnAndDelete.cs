using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class UnitSpawnAndDelete : MonoBehaviour, IUnitSpawnAndDelete
{
    [SerializeField] private GameObject _unitExample;
    [SerializeField] private float _radius;
    
    private int _nextSpawnedUnitCircleIndex;
    private int _nextSpawnedUnitIndex;
    
    public List<GameObject> SpawnUnits(int unitsCount)
    {
        var spawnedUnits = new List<GameObject>();
        
        for(; unitsCount != 0;)
        {
            var currentCircleRadius = _radius * _nextSpawnedUnitCircleIndex;
            var maxUnitsCountAtCircle = CalculateMaxUnitsCountAtCircle(_nextSpawnedUnitCircleIndex);
            var missingUnitsCountAtCircle = maxUnitsCountAtCircle - _nextSpawnedUnitIndex;
            
            var currentCircleUnitsSpawning = missingUnitsCountAtCircle > unitsCount ? unitsCount : missingUnitsCountAtCircle;
            var angleSection = Mathf.PI * 2 / maxUnitsCountAtCircle;

            for (int i = 0; i < currentCircleUnitsSpawning; _nextSpawnedUnitIndex++, unitsCount--, i++)
            {
                float angle = _nextSpawnedUnitIndex * angleSection;
                Vector3 newPos = _unitExample.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * currentCircleRadius;
                var unit = Instantiate(_unitExample, newPos, _unitExample.transform.rotation);
                unit.SetActive(true);
                unit.transform.SetParent(transform);
                spawnedUnits.Add(unit);
            }

            if (currentCircleUnitsSpawning != missingUnitsCountAtCircle) continue;
            _nextSpawnedUnitCircleIndex++;
            _nextSpawnedUnitIndex = 0;
        }

        return spawnedUnits;
    }
    
    public void DeleteUnits(int armyCount, ref List<GameObject> units)
    {
        for (int i = 0; i < armyCount; i++)
        {
            var removingUnitIndex = units.Count - 1;
            Destroy(units[removingUnitIndex]);
            units.RemoveAt(removingUnitIndex);
            
            if (_nextSpawnedUnitIndex == 0)
            {
                _nextSpawnedUnitCircleIndex--;
                _nextSpawnedUnitIndex = CalculateMaxUnitsCountAtCircle(_nextSpawnedUnitCircleIndex) - 1;
                continue;
            }
            _nextSpawnedUnitIndex--;
        }
    }

    private int CalculateMaxUnitsCountAtCircle(int circleIndex)
    {
        var currentCircleRadius = _radius * circleIndex;
        if (currentCircleRadius == 0) return 1;
        return (int) (2 * Mathf.PI * currentCircleRadius / _unitExample.transform.lossyScale.x);
    }
}
