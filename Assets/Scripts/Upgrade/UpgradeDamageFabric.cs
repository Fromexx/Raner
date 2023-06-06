using Interfaces;
using Player;
using UnityEngine;

namespace Upgrade
{
    public class UpgradeDamageFabric : MonoBehaviour, IUpgradeFabric
    {
        [SerializeField] private int _price;
        [SerializeField] private EnemyArmy _enemyArmy;
        [SerializeField] private PlayerArmy _playerArmy;
        
        public void Upgrade()
        {
            if (Wallet.Money < _price) return;

            Wallet.RemoveMoney(_price);
            _price += 5;
            _enemyArmy.IncreaseUnitsHealth(5);
            _playerArmy.Damage = _enemyArmy.GetStartUnitHealth() / 4;
        }
    }
}