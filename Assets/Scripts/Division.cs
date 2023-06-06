using Player;
using UnityEngine;

public class Division : MonoBehaviour
{
    // ДИЧЬ
    private int _value;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerArmy army)) return;
        
        _value = Random.Range(2, 5);

        while (army.ArmyCount % _value != 0)
        {
            _value = Random.Range(2, 5);
        }
        army.OnUnitsSpawning(army.ArmyCount / _value);
    }
}
