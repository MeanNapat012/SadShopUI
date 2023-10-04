using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    [SerializeField] TMP_Text CoinText;
    [SerializeField] int money = 1000;

    public int CurrentCoin 
    {
        get { return money; }
        set { money = value; }
    }

    void Update()
    {
        CoinText.text = "Coin : " + money;
    }
}
