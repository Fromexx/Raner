using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float attackRadius;
    Animator animator;
    Army army;

    private void Start()
    {
        army = FindObjectOfType<Army>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        { 
            army.ArmyCount--;
            army.units.Remove(gameObject);
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
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider enemy in enemies)
        {
            if (enemy.CompareTag("EnemyUnit"))
            {
                enemy.GetComponent<EnemyUnit>().TakeDamage(army.damage);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyUnit"))
        {
            //анимация
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
