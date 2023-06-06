using UnityEngine;

namespace Player
{
    public class PlayerArmyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        public void MoveAtPosition(Vector3 targetPosition) => transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        public void Movement(Vector3 direction) => transform.Translate(direction * _speed, Space.World);
    }
}