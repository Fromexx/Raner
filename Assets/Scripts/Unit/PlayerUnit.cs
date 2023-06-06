using Player;
using UnityEngine;

public class PlayerUnit : Unit.Unit
{
    protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out PlayerArmy _);
}
