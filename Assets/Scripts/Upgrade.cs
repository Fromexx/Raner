using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    Army army;
    EnemyArmy enemyArmy;
    Balance balance;
    public TextMeshProUGUI damagePriceText;
    //public TextMeshProUGUI rewardPriceText;
    
   [SerializeField] int damagePrice;
   [SerializeField] int rewardPrice;

    private void Start()
    {
        army = FindObjectOfType<Army>();
        balance = FindObjectOfType<Balance>();
        enemyArmy = FindObjectOfType<EnemyArmy>();
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
            balance.balance -= damagePrice;
            damagePrice += 5;
            enemyArmy.startUnitsHealth += 5;
            army.damage = enemyArmy.startUnitsHealth / 4;            
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
