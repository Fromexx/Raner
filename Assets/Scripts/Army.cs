using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    public GameObject unitExample;
    public List<GameObject> units;
    public int armyCount = 1;
    public float speed;
    public float damage;

    [SerializeField] private float _radius;

    private float _unitYPosition;

    public void OnArmyIncrease()
    {
        armyCount++;
        SpawnArmy();
    }

    public void OnArmyDecrease()
    {
        armyCount--;
        SpawnArmy();
    }

    private void SpawnArmy()
    {
        DeleteArmy();
        var remainingArmy = armyCount;

        for (int c = 1; ; c++)
        {
            if (remainingArmy == 0) break;

            var currentCircleRadius = _radius * c;
            var maxUnitsCountAtCircle = (int) (2 * Mathf.PI * currentCircleRadius / unitExample.transform.lossyScale.x);
            var unitsCount = maxUnitsCountAtCircle > remainingArmy ? remainingArmy : maxUnitsCountAtCircle;
            var angleSection = Mathf.PI * 2 / unitsCount;

            for (int i = 0; i < unitsCount; i++)
            {
                float angle = i * angleSection;
                Vector3 newPos = unitExample.transform.position + new Vector3(Mathf.Cos(angle), _unitYPosition, Mathf.Sin(angle)) * currentCircleRadius;
                var unit = Instantiate(unitExample, newPos, unitExample.transform.rotation);
                unit.transform.SetParent(transform);
                units.Add(unit);
                remainingArmy--;
            }
        }
    }

    private void DeleteArmy()
    {
        for (int i = units.Count; i > 0; i--)
        {
            print(i);
            Destroy(units[units.Count - 1]);
            units.RemoveAt(units.Count - 1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
} 