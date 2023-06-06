using UnityEngine;

<<<<<<< Updated upstream
public class EnemyUnit : Unit.Unit
{
    protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out EnemyArmy _);
=======
<<<<<<< HEAD
public class EnemyUnit : Unit
{   
    private void Start()
    {        
        Health = army.startUnitsHealth;
    }
   
=======
public class EnemyUnit : Unit.Unit
{
    protected override bool IsColliderValid(Collider collider) => !collider.TryGetComponent(out EnemyArmy _);
>>>>>>> 5a5e2b9ac7f348b01d9cc3f0fa3c5d7841f4bf5d
>>>>>>> Stashed changes
}
