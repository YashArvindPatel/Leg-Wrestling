using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsInfo2Players : MonoBehaviour
{
    private int player1Coins = 0;
    private int player2Coins = 0;

    private void OnEnable()
    {
        player1Coins = PlayerPrefs.GetInt("s2P1Coins");
        player2Coins = PlayerPrefs.GetInt("s2P2Coins");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("s2P1Coins", player1Coins);
        PlayerPrefs.SetInt("s2P2Coins", player2Coins);
    }

    public void SetP1Coins(int coins)
    {
        this.player1Coins = coins;
    }

    public void SetP2Coins(int coins)
    {
        this.player2Coins = coins;
    }

    public int GetP1Coins()
    {
        return player1Coins;
    }

    public int GetP2Coins()
    {
        return player2Coins;
    }
}
