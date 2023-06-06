using UnityEngine;

namespace Player
{
    public class PlayerArmy : Army
    {
        [SerializeField] private FixedJoystick _fixedJoystick;

        private PlayerArmyMovement _playerArmyMovement;

        private void Awake()
        {
            TryGetComponent(out _playerArmyMovement);
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            var direction = new Vector3(_fixedJoystick.Direction.x, 0, _fixedJoystick.Direction.y);
            _playerArmyMovement.Movement(direction);
        }

        public void MoveArmyAtPosition(Vector3 targetPosition) => _playerArmyMovement.MoveAtPosition(targetPosition);
    }
}
