using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float attackRadius;

    Animator animator;
    EnemyArmy enemyArmy;

    private void Start()
    {
        enemyArmy = FindObjectOfType<EnemyArmy>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            enemyArmy.units.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }

    public void Attack()
    {
        Collider[] units = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider unit in units)
        {
            if (unit.CompareTag("PlayerUnit"))
            {
                unit.GetComponent<PlayerUnit>().TakeDamage(enemyArmy.damage);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerUnit"))
        {
            //Анимация
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
