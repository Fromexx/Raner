using Assets.Scripts.Army;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform attackPoint;

    private void OnAttacking()
    {        
        var units = Physics.OverlapSphere(attackPoint.position, _radius);
        
        foreach (var unit in units)
        {
            if (!unit.TryGetComponent(out Army army)) continue;
            
            army.OnUnitsDeleting(army.ArmyCount);
            break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, _radius);
    }
}
