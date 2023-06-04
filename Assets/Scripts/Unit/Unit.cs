using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float attackRadius;
    protected Army army;
    Animator animator;

    private void Start()
    {   
        army = GetComponentInParent<Army>();
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        Collider[] units = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider unit in units)
        {
            if (unit.GetComponent<Army>())
            {
                unit.GetComponent<Unit>().TakeDamage(army.Damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Army>())
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
