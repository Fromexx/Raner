using UnityEngine;

public class Addition : MonoBehaviour
{
    int value;
    Army army;


    private void Start()
    {
        army = FindObjectOfType<Army>();
        value = Random.Range(1, 200);       
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Army"))
        {
            army.OnArmyCountChanged(army.armyCount + value);
        }
    }
}
