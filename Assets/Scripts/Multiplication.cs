using UnityEngine;

public class Multiplication : MonoBehaviour
{
    private int _value;
    
    private void Awake()
    {
        _value = Random.Range(2, 5);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Army army))
        {
            army.OnUnitsSpawning(army.ArmyCount * _value);
        }
    }
}
