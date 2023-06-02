using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    int armyCount;
    Army army;
    public GameObject unit;
    public List<GameObject> units;
    public float radius;
    public int damage;
    float minDistance;
    float maxDistance;
    bool fight;

    private void Start()
    {
        radius = Random.Range(5f, 10f);
        maxDistance = radius + 10;
        minDistance = radius;
        armyCount = Random.Range(5, 200);
        army = FindObjectOfType<Army>(); 
        
        for (int i = 0; i < armyCount; i++)
        {
            GameObject newUnit = Instantiate(unit, transform.position, unit.transform.rotation);
            newUnit.transform.SetParent(transform);
            units.Add(newUnit);
            newUnit.transform.localPosition = new Vector3(Random.Range(-radius, radius), 0f, Random.Range(-radius, radius));
        }       
    }

    private void Update()
    {
        if (armyCount <= 0)
        {
            Destroy(gameObject);         
        }

        Spawn();

        Collider[] units = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider unit in units)
        {
            if (unit.CompareTag("Army") && fight == false)
            {
                fight = true;
                StartCoroutine(Fighting());
                break;
            }
        }

        float distance = Vector3.Distance(army.transform.position, transform.position);
        
        if (distance < maxDistance)
        {
            if (distance > minDistance)
            {
                army.transform.position = Vector3.MoveTowards(army.transform.position, transform.position, army.speed * Time.deltaTime);
            }
        }
    }

    void Spawn()
    {
        if (transform.childCount > armyCount)
        {
            for (int i = units.Count; i > armyCount; i--)
            {
                Destroy(units[units.Count - 1]);
                units.RemoveAt(units.Count - 1);
            }
        }       
    }

    IEnumerator Fighting()
    {
        while (armyCount > 0 && army.armyCount > 0)
        {
            army.armyCount -= damage;
            armyCount -= army.damage;
            yield return new WaitForSeconds(0.05f);
        }
        fight = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
