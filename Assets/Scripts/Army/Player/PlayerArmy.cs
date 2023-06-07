using UnityEngine;

namespace Assets.Scripts.Army.Player
{
    public class PlayerArmy : Army
    {
        private PlayerArmyMovement _playerArmyMovement;

        private void Awake()
        {
            TryGetComponent(out _playerArmyMovement);
            OnUnitsSpawning(1);
        }

        public void MoveArmyAtPosition(Vector3 targetPosition) => _playerArmyMovement.MoveAtPosition(targetPosition);
    }
}
