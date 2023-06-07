using UnityEngine;

namespace Player
{
    public class PlayerArmyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 _direction;
        private InputManager _inputManager;

        private void Awake()
        {
            _inputManager = new InputManager();
            _inputManager.Enable();
        }

        public void FixedUpdate()
        {
            Vector2 receivedVector = _inputManager.Player.Move.ReadValue<Vector2>();
            _direction = new Vector3(receivedVector.x, 0, receivedVector.y);
            transform.Translate(_direction * (_speed * Time.fixedDeltaTime), Space.World);
        }

        public void MoveAtPosition(Vector3 targetPosition) => transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}