using UnityEngine;

public class Addition : MonoBehaviour
{
    int value;
    Army army;


    private void Start()
    {
        army = FindObjectOfType<Army>();
        value = Random.Range(1, 200);
        army.armyCount += value;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.armyCount += value;
        }
    }
}
