using UnityEngine;

public class Subtraction : MonoBehaviour
{
    private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Army army))
        {
            while (army.ArmyCount <= _value)
            {
                _value = Random.Range(1, 200);
            }
            
            army.OnUnitsSpawning(army.ArmyCount - _value);
        }
    }
}
