using UnityEngine;

public class Addition : MonoBehaviour
{
    private int _value = Random.Range(1, 200);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Army army))
        {
            army.OnUnitsSpawning(_value);
        }
    }
}
