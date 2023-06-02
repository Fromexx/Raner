using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    Army army;
    Balance balance;
    public TextMeshProUGUI damagePriceText;
    //public TextMeshProUGUI rewardPriceText;
    
   [SerializeField] int damagePrice;
   [SerializeField] int rewardPrice;

    private void Start()
    {
        army = FindObjectOfType<Army>();
        balance = FindObjectOfType<Balance>();
    }

    private void Update()
    {
        damagePriceText.SetText(damagePrice.ToString());
        //rewardPriceText.SetText(rewardPrice.ToString());
    }

    public void UpgradeDamage()
    {
        if (balance.balance >= damagePrice)
        {
            army.damage *= 2;
            balance.balance -= damagePrice;
            damagePrice += 10;
        }       
    }

    public void UpgradeReward()
    {
        if (balance.balance >= rewardPrice)
        {
            balance.balance -= rewardPrice;
            rewardPrice += 10;
        }        
    }
}
