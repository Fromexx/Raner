using System;
using UnityEngine;

namespace Unit
{
<<<<<<< Updated upstream
    public abstract class Unit : MonoBehaviour
=======
<<<<<<< HEAD
    [SerializeField] public int Health { get; set; }
    [SerializeField] protected float attackRadius;
    protected Army army;
    private Animator animator;

    private void Start()
    {   
        army = GetComponentInParent<Army>();
        animator = GetComponent<Animator>();
    }

    public void Attack()
=======
    public abstract class Unit : MonoBehaviour
>>>>>>> 5a5e2b9ac7f348b01d9cc3f0fa3c5d7841f4bf5d
>>>>>>> Stashed changes
    {
        public event Action<Unit> UnitDied;

        [SerializeField] private float _damage;
        [SerializeField] private float _attackRadius;
        [SerializeField] private Animator _animator;
        
        private float _health;

        private void Awake()
        {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
            if (unit.gameObject.TryGetComponent(out Unit unit1))
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
>>>>>>> 5a5e2b9ac7f348b01d9cc3f0fa3c5d7841f4bf5d
>>>>>>> Stashed changes
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
                //ÐÐ½Ð¸Ð¼Ð°Ñ†Ð¸Ñ
                Attack();
            }
        }
    }
<<<<<<< Updated upstream
}
=======
<<<<<<< HEAD

    public void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            
            Destroy(gameObject);
        }
        else
        {
            Health -= damage;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Army army))
        {
            
            //Àíèìàöèÿ
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
=======
}
>>>>>>> 5a5e2b9ac7f348b01d9cc3f0fa3c5d7841f4bf5d
>>>>>>> Stashed changes
