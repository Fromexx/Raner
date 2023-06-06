using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmy : Army
{
    [SerializeField] private float speed;
    private Army army;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;

    private void Start()
    {
        army = FindAnyObjectByType<EnemyArmy>();
        OnArmyCountChanged(1);
    }

    private void Update()
    {
        float distance = Vector3.Distance(army.transform.position, transform.position);

        if (distance < maxDistance)
        {
            if (distance > minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, army.transform.position, speed * Time.deltaTime);
            }
        }
    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
