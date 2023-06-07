using Assets.Scripts.Army.Player;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class PlayerUnit : Unit
    {
        protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out PlayerArmy _);
    }
}