using Player;
using UnityEngine;

namespace Fight
{
    public class Fight : MonoBehaviour
    {
        private PlayerArmy _playerArmy;
        private EnemyArmy _enemyArmy;
        private float _minDistance;
        private float _maxDistance;
        private bool _isFight;

        public void StartFight()
        {
            var distance = Vector3.Distance(_playerArmy.transform.position, _enemyArmy.transform.position);

            if (distance > _minDistance && distance < _maxDistance)
            {
                _playerArmy.MoveArmyAtPosition(_enemyArmy.transform.position);
            }
        }
    }
}