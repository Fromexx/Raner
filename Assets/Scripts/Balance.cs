using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balance : MonoBehaviour
{
    public int balance;
    public TextMeshProUGUI balanceText;

    private void Update()
    {
        balanceText.SetText(balance.ToString());
    }
}
