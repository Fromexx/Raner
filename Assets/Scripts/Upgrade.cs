using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private Army playerArmy;
    private Army enemyArmy;
    private Balance balance;
    [SerializeField] private TextMeshProUGUI damagePriceText;
    //[SerializeField] private TextMeshProUGUI rewardPriceText;
    
   [SerializeField] private int damagePrice;
   [SerializeField] private int rewardPrice;

    private void Start()
    {
        playerArmy = FindObjectOfType<PlayerArmy>();
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
            playerArmy.Damage = enemyArmy.startUnitsHealth / 4;            
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
