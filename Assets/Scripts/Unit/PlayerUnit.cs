using Player;
using UnityEngine;

public class PlayerUnit : Unit.Unit
{
<<<<<<< Updated upstream
    protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out PlayerArmy _);
=======
<<<<<<< HEAD
  
=======
    protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out PlayerArmy _);
>>>>>>> 5a5e2b9ac7f348b01d9cc3f0fa3c5d7841f4bf5d
>>>>>>> Stashed changes
}
