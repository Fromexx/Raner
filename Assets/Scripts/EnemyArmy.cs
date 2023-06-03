using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    int armyCount;
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
        armyCount = Random.Range(5, 200);
        army = FindObjectOfType<Army>();

        _nextSpawnedUnitCircleIndex = 0;
        _nextSpawnedUnitIndex = 0;

        SpawnArmy();
    }

    private void Update()
    {
        if (armyCount <= 0)
        {
            Destroy(gameObject);         
        }      

        float distance = Vector3.Distance(army.transform.position, transform.position);
        
        if (distance < maxDistance)
        {
            if (distance > minDistance)
            {
                army.transform.position = Vector3.MoveTowards(army.transform.position, transform.position, army.speed * Time.deltaTime);
            }
        }
    }

    private void SpawnArmy()
    {
        var remainingArmy = armyCount - units.Count;

        for (; remainingArmy != 0;)
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

    private int CalculateMaxUnitsCountAtCircle(int circleIndex)
    {
        var currentCircleRadius = _radius * circleIndex;
        if (currentCircleRadius == 0) return 1;
        return (int)(2 * Mathf.PI * currentCircleRadius / unitExample.transform.lossyScale.x);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
