using Interfaces;
using UnityEngine;

namespace Upgrade
{
    public class UpgradeRewardFabric : MonoBehaviour, IUpgradeFabric
    {
        [SerializeField] private int _price;

        public void Upgrade()
        {
            if (Wallet.Money < _price) return;
            
            Wallet.RemoveMoney(_price);
            _price += 10;
        }
    }
}