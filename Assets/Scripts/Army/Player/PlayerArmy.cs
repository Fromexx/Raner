using UnityEngine;

namespace Player
{
    public class PlayerArmy : Army
    {
        private PlayerArmyMovement _playerArmyMovement;

        private void Awake()
        {
            TryGetComponent(out _playerArmyMovement);
        }

        public void MoveArmyAtPosition(Vector3 targetPosition) => _playerArmyMovement.MoveAtPosition(targetPosition);
    }
}
