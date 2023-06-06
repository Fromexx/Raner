using UnityEngine;

public class Hammer : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    public void Attack()
    {
        var units = Physics.OverlapSphere(transform.position, _radius);
        
        foreach (var unit in units)
        {
=======
<<<<<<< HEAD
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    private PlayerArmy army;

    private void Start()
    {
        army = FindObjectOfType<PlayerArmy>();
    }

    public void Attack()
    {
        Collider[] units = Physics.OverlapSphere(attackPoint.position, radius);
        foreach (Collider unit in units)
        {
            if (unit.CompareTag("PlayerUnit"))
            {
                army.ArmyCount--;
                army.units.Remove(unit.gameObject);                
                Destroy(unit.gameObject);                              
            }
=======
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    public void Attack()
    {
        var units = Physics.OverlapSphere(transform.position, _radius);
        
        foreach (var unit in units)
        {
>>>>>>> Stashed changes
            if (!unit.TryGetComponent(out Army army)) continue;
            
            army.OnUnitsDeleting(army.ArmyCount);
            break;
<<<<<<< Updated upstream
=======
>>>>>>> 5a5e2b9ac7f348b01d9cc3f0fa3c5d7841f4bf5d
>>>>>>> Stashed changes
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
