using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store2 : MonoBehaviour
{
    public GameObject menuPanel;

    public Image buyButtonImage1, buyButtonImage2;
    public Image footPlaceholder1, footPlaceholder2;

    public Sprite buySprite, shoesSprite, doneSprite;

    public GameObject coinDetails1, coinDetails2, boughtIcon1, boughtIcon2;

    public TextMeshProUGUI coinsText1, coinsText2;
    public TextMeshProUGUI coinCostText1, coinCostText2;

    public AudioClip buyClip, buttonClip;

    private int counter1 = 0, counter2 = 0;

    private int player1Coins = 0, player2Coins = 0;

    public Sprite[] skins;
    public int[] skinCost;

    private void Start()
    {
        player1Coins = FindObjectOfType<CoinsInfo2Players>().GetP1Coins();
        player2Coins = FindObjectOfType<CoinsInfo2Players>().GetP2Coins();

        coinsText1.text = player1Coins.ToString();
        coinsText2.text = player2Coins.ToString();

        CheckIfPlayer1Bought(counter1);
        CheckIfPlayer2Bought(counter2);
    }

    public void BackButtonClicked()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Player1Buy()
    {
        int costOfSkin = System.Convert.ToInt32(coinCostText1.text);

        if (player1Coins >= costOfSkin && buyButtonImage1.sprite != doneSprite)
        {
            FindObjectOfType<SkinsOwned2Players>().firstPlayerSkins[counter1] = true;
            player1Coins -= costOfSkin;
            coinsText1.text = player1Coins.ToString();
            FindObjectOfType<CoinsInfo2Players>().SetP1Coins(player1Coins);
            CheckIfPlayer1Bought(counter1);
        }
    }

    public void Player2Buy()
    {
        int costOfSkin = System.Convert.ToInt32(coinCostText2.text);

        if (player2Coins >= costOfSkin && buyButtonImage2.sprite != doneSprite)
        {
            FindObjectOfType<SkinsOwned2Players>().secondPlayerSkins[counter2] = true;
            player2Coins -= costOfSkin;
            coinsText2.text = player2Coins.ToString();
            FindObjectOfType<CoinsInfo2Players>().SetP2Coins(player2Coins);
            CheckIfPlayer2Bought(counter2);
        }
    }

    public void Player1Left()
    {
        if (counter1 == 0)
        {
            return;
        }
        else
        {
            counter1--;
            footPlaceholder1.sprite = skins[counter1];
            CheckIfPlayer1Bought(counter1);
        }
    }

    public void Player2Left()
    {
        if (counter2 == 0)
        {
            return;
        }
        else
        {
            counter2--;
            footPlaceholder2.sprite = skins[counter2];
            CheckIfPlayer2Bought(counter2);
        }
    }

    public void Player1Right()
    {
        if (counter1 == 7)
        {
            return;
        }
        else
        {
            counter1++;
            footPlaceholder1.sprite = skins[counter1];
            CheckIfPlayer1Bought(counter1);
        }
    }

    public void Player2Right()
    {
        if (counter2 == 7)
        {
            return;
        }
        else
        {
            counter2++;
            footPlaceholder2.sprite = skins[counter2];
            CheckIfPlayer2Bought(counter2);
        }
    }

    public void SelectSkinAndShoesP1()
    {
        if (counter1 <= 3)
        {
            FindObjectOfType<SkinsAndShoes>().SetStore2P1Skin(counter1 + 1);
        }
        else
        {
            FindObjectOfType<SkinsAndShoes>().SetStore2P1Shoes(counter1 + 1);
        }

        boughtIcon1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void SelectSkinAndShoesP2()
    {
        if (counter2 <= 3)
        {
            FindObjectOfType<SkinsAndShoes>().SetStore2P2Skin(counter2 + 1);
        }
        else
        {
            FindObjectOfType<SkinsAndShoes>().SetStore2P2Shoes(counter2 + 1);
        }

        boughtIcon2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void CheckIfPlayer1Bought(int counter)
    {
        if (FindObjectOfType<SkinsOwned2Players>().firstPlayerSkins[counter])
        {
            buyButtonImage1.sprite = doneSprite;
            buyButtonImage1.GetComponent<ButtonClicked>().audioClip = buttonClip;
            coinDetails1.SetActive(false);
            boughtIcon1.SetActive(true);


            if (FindObjectOfType<SkinsAndShoes>().GetStore2P1Skin() == counter1 + 1 || FindObjectOfType<SkinsAndShoes>().GetStore2P1Shoes() == counter1 + 1)
            {
                boughtIcon1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                boughtIcon1.GetComponent<Image>().color = new Color32(255, 255, 255, 125);
            }
        }
        else
        {
            if (counter <= 3)
            {
                buyButtonImage1.sprite = buySprite;
            }
            else
            {
                buyButtonImage1.sprite = shoesSprite;
            }

            coinCostText1.text = skinCost[counter].ToString();

            buyButtonImage1.GetComponent<ButtonClicked>().audioClip = buyClip;
            coinDetails1.SetActive(true);
            boughtIcon1.SetActive(false);
        }

        if (buyButtonImage1.sprite != doneSprite)
        {
            if (player1Coins < System.Convert.ToInt32(coinCostText1.text))
            {
                buyButtonImage1.gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                buyButtonImage1.gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            buyButtonImage1.gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void CheckIfPlayer2Bought(int counter)
    {
        if (FindObjectOfType<SkinsOwned2Players>().secondPlayerSkins[counter])
        {
            buyButtonImage2.sprite = doneSprite;
            buyButtonImage2.GetComponent<ButtonClicked>().audioClip = buttonClip;
            coinDetails2.SetActive(false);
            boughtIcon2.SetActive(true);


            if (FindObjectOfType<SkinsAndShoes>().GetStore2P2Skin() == counter2 + 1 || FindObjectOfType<SkinsAndShoes>().GetStore2P2Shoes() == counter2 + 1)
            {
                boughtIcon2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                boughtIcon2.GetComponent<Image>().color = new Color32(255, 255, 255, 125);
            }
        }
        else
        {
            if (counter <= 3)
            {
                buyButtonImage2.sprite = buySprite;
            }
            else
            {
                buyButtonImage2.sprite = shoesSprite;
            }

            coinCostText2.text = skinCost[counter].ToString();

            buyButtonImage2.GetComponent<ButtonClicked>().audioClip = buyClip;
            coinDetails2.SetActive(true);
            boughtIcon2.SetActive(false);
        }

        if (buyButtonImage2.sprite != doneSprite)
        {
            if (player2Coins < System.Convert.ToInt32(coinCostText2.text))
            {
                buyButtonImage2.gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                buyButtonImage2.gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            buyButtonImage2.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
