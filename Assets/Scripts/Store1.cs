using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store1 : MonoBehaviour
{
    public GameObject menuPanel;

    public Image buyButtonImage;
    public Image footPlaceholder;

    public Sprite buySprite, shoesSprite, doneSprite;

    public GameObject coinDetails, boughtIcon;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI coinCostText;

    public AudioClip buyClip, buttonClip;

    private int counter = 0;

    private int coins = 0;

    public Sprite[] skins;
    public int[] skinCost;

    private void Start()
    {
        coins = FindObjectOfType<CoinsInfo>().GetCoins();
        coinsText.text = coins.ToString();
        CheckIfBought(counter);
    }

    public void BackButtonClicked()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Buy()
    {
        int costOfSkin = System.Convert.ToInt32(coinCostText.text);

        if (coins >= costOfSkin && buyButtonImage.sprite != doneSprite)
        {
            FindObjectOfType<SkinsOwned>().skinsOwned[counter] = true;
            coins -= costOfSkin;
            coinsText.text = coins.ToString();
            FindObjectOfType<CoinsInfo>().SetCoins(coins);
            CheckIfBought(counter);
        }        
    }

    public void Left()
    {
        if (counter == 0)
        {
            return;
        }
        else
        {
            counter--;
            footPlaceholder.sprite = skins[counter];
            CheckIfBought(counter);
        }
    }

    public void Right()
    {
        if (counter == 7)
        {
            return;
        }
        else
        {
            counter++;
            footPlaceholder.sprite = skins[counter];
            CheckIfBought(counter);
        }
    }

    public void SelectSkinAndShoes()
    {
        if (counter <= 3)
        {
            FindObjectOfType<SkinsAndShoes>().SetStore1Skin(counter + 1);
        }
        else
        {
            FindObjectOfType<SkinsAndShoes>().SetStore1Shoes(counter + 1);
        }

        boughtIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void CheckIfBought(int counter)
    {
        if (FindObjectOfType<SkinsOwned>().skinsOwned[counter])
        {
            buyButtonImage.sprite = doneSprite;
            buyButtonImage.GetComponent<ButtonClicked>().audioClip = buttonClip;
            coinDetails.SetActive(false);
            boughtIcon.SetActive(true);

            if (FindObjectOfType<SkinsAndShoes>().GetStore1Skin() == counter + 1 || FindObjectOfType<SkinsAndShoes>().GetStore1Shoes() == counter + 1)
            {
                boughtIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                boughtIcon.GetComponent<Image>().color = new Color32(255, 255, 255, 125);
            }
        }
        else
        {
            if (counter <= 3)
            {
                buyButtonImage.sprite = buySprite;
            }
            else
            {
                buyButtonImage.sprite = shoesSprite;
            }

            coinCostText.text = skinCost[counter].ToString();

            buyButtonImage.GetComponent<ButtonClicked>().audioClip = buyClip;
            coinDetails.SetActive(true);
            boughtIcon.SetActive(false);
        }

        if (buyButtonImage.sprite != doneSprite)
        {
            if (coins < System.Convert.ToInt32(coinCostText.text))
            {
                buyButtonImage.gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                buyButtonImage.gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            buyButtonImage.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
