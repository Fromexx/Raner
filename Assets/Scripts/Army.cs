using System;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    public GameObject unitExample;
    public List<GameObject> units;
    public int armyCount = 1;
    public float radius;
    public float speed;
    public int damage;

    [SerializeField] private float _radius;

    private int _nextSpawnedUnitCircleIndex;
    private int _nextSpawnedUnitIndex;

    private void Awake()
    {
        _nextSpawnedUnitCircleIndex = 0;
        _nextSpawnedUnitIndex = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) OnArmyIncrease();
        else if(Input.GetKeyDown(KeyCode.Y)) OnArmyDecrease();
    }

    public void OnArmyIncrease()
    {
        armyCount++;
        SpawnArmy();
    }

    public void OnArmyDecrease()
    {
        armyCount--;
        DeleteArmy();
    }

    private void SpawnArmy()
    {
        var remainingArmy = armyCount - units.Count;

        for(; remainingArmy != 0;)
        {
            var currentCircleRadius = _radius * _nextSpawnedUnitCircleIndex;
            var maxUnitsCountAtCircle = CalculateMaxUnitsCountAtCircle(_nextSpawnedUnitCircleIndex);
            var missingUnitsCountAtCircle = maxUnitsCountAtCircle - _nextSpawnedUnitIndex;
            
            var unitsCount = missingUnitsCountAtCircle > remainingArmy ? remainingArmy : missingUnitsCountAtCircle;
            var angleSection = Mathf.PI * 2 / maxUnitsCountAtCircle;

            for (int i = 0; i < unitsCount; _nextSpawnedUnitIndex++, remainingArmy--, i++)
            {
                float angle = _nextSpawnedUnitIndex * angleSection;
                Vector3 newPos = unitExample.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * currentCircleRadius;
                var unit = Instantiate(unitExample, newPos, unitExample.transform.rotation);
                unit.SetActive(true);
                unit.transform.SetParent(transform);
                units.Add(unit);
            }

            if (unitsCount != missingUnitsCountAtCircle) continue;
            _nextSpawnedUnitCircleIndex++;
            _nextSpawnedUnitIndex = 0;
        }
    }

    private void DeleteArmy()
    {
        var remainingArmy = units.Count - armyCount;

        for (int i = 0; i < remainingArmy; i++)
        {
            DeleteUnit(units.Count - 1);
            if (_nextSpawnedUnitIndex == 0)
            {
                _nextSpawnedUnitCircleIndex--;
                _nextSpawnedUnitIndex = CalculateMaxUnitsCountAtCircle(_nextSpawnedUnitCircleIndex);
                continue;
            }
            _nextSpawnedUnitIndex--;
        }
    }

    private int CalculateMaxUnitsCountAtCircle(int circleIndex)
    {
        var currentCircleRadius = _radius * circleIndex;
        if (currentCircleRadius == 0) return 1;
        return (int) (2 * Mathf.PI * currentCircleRadius / unitExample.transform.lossyScale.x);
    }

    private void DeleteUnit(int index)
    {
        Destroy(units[index]);
        units.RemoveAt(index);
    }
} 