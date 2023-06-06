using UnityEngine;

public class EnemyUnit : Unit.Unit
{
    protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out EnemyArmy _);
}
