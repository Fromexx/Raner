using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    public void Attack()
    {
        var units = Physics.OverlapSphere(transform.position, _radius);
        
        foreach (var unit in units)
        {
            if (!unit.TryGetComponent(out Army army)) continue;
            
            army.OnUnitsDeleting(army.ArmyCount);
            break;
        }
    }
}
