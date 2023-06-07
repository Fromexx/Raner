using Assets.Scripts.Army.Enemy;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class EnemyUnit : Unit
    {
        protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out EnemyArmy _);
    }
}