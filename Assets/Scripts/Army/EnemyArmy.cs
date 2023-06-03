using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    int _armyCount;
    public int startUnitsHealth;
    Army army;
    public GameObject unitExample;
    public List<GameObject> units;
    public int damage = 5;
    float minDistance;
    float maxDistance;
    bool fight;

    [SerializeField] private float _radius;

    private int _nextSpawnedUnitCircleIndex;
    private int _nextSpawnedUnitIndex;

    private void Start()
    {
        _armyCount = Random.Range(5, 200);
        army = FindObjectOfType<Army>();

        _nextSpawnedUnitCircleIndex = 0;
        _nextSpawnedUnitIndex = 0;
        
        SpawnArmy(_armyCount);
    }

    private void Update()
    {
        float distance = Vector3.Distance(army.transform.position, transform.position);
        
        if (distance < maxDistance)
        {
            if (distance > minDistance)
            {
                army.transform.position = Vector3.MoveTowards(army.transform.position, transform.position, army.speed * Time.deltaTime);
            }
        }
    }

    private void SpawnArmy(int armyCount)
    {
        for(; armyCount != 0;)
        {
            var currentCircleRadius = _radius * _nextSpawnedUnitCircleIndex;
            var maxUnitsCountAtCircle = CalculateMaxUnitsCountAtCircle(_nextSpawnedUnitCircleIndex);
            var missingUnitsCountAtCircle = maxUnitsCountAtCircle - _nextSpawnedUnitIndex;
            
            var unitsCount = missingUnitsCountAtCircle > armyCount ? armyCount : missingUnitsCountAtCircle;
            var angleSection = Mathf.PI * 2 / maxUnitsCountAtCircle;

            for (int i = 0; i < unitsCount; _nextSpawnedUnitIndex++, armyCount--, i++)
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

    private void DeleteArmy(int armyCount)
    {
        for (int i = 0; i < armyCount; i++)
        {
            DeleteUnit(units.Count - 1);
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
        return (int) (2 * Mathf.PI * currentCircleRadius / unitExample.transform.lossyScale.x);
    }

    private void DeleteUnit(int index)
    {
        Destroy(units[index]);
        units.RemoveAt(index);
    }
}
