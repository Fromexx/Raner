using UnityEngine;

public class EnemyArmy : Army
{
    [SerializeField] private int _startUnitsHealth;

    private void Awake()
    {
        OnUnitsSpawning(Random.Range(5, 200));

        foreach (var unitGameObject in Units)
        {
            unitGameObject.TryGetComponent(out Unit.Unit unit);
            unit.Init(_startUnitsHealth);
        }
    }

    public void IncreaseUnitsHealth(float increaseScalar) => _startUnitsHealth += 5;

    public int GetStartUnitHealth() => _startUnitsHealth;
}
