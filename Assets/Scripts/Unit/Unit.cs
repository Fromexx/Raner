using System;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class Unit : MonoBehaviour
    {
        public event Action<Unit> UnitDied;

        [SerializeField] private float _damage;
        [SerializeField] private float _attackRadius;
        [SerializeField] private Animator _animator;
        
        private float _health;

        private void Awake()
        {
            TryGetComponent(out _animator);
        }

        public void Init(float health)
        {
            _health = health;
        }

        private void Attack()
        {
            var unitsColliders = Physics.OverlapSphere(transform.position, _attackRadius);
            foreach (var unitCollider in unitsColliders)
            {
                if (!IsColliderValid(unitCollider)) return;
                
                if (unitCollider.TryGetComponent(out Unit unit))
                {
                    unit.TakeDamage(_damage);
                }
            }
        }

        protected abstract bool IsColliderValid(Collider collider);

        private void TakeDamage(float damage)
        {
            _health -= damage;
            if(_health <= 0) UnitDied?.Invoke(this);
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!IsColliderValid(other)) return;
            
            if (other.TryGetComponent(out Unit _))
            {
                //Анимация
                Attack();
            }
        }
    }
}