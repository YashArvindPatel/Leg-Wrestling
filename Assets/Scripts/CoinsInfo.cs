using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsInfo : MonoBehaviour
{
    private int coins = 0;

    private void OnEnable()
    {
        coins = PlayerPrefs.GetInt("s1Coins");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("s1Coins", coins);
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
    }
    
    public int GetCoins()
    {
        return this.coins;
    }
}
