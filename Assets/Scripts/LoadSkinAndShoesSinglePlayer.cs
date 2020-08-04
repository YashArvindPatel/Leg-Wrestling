using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSkinAndShoesSinglePlayer : MonoBehaviour
{
    private int store1Skin = 0;
    private int store1Shoes = 0;

    public Image leftLeg, leftShoe, rightLeg, rightShoe;

    public Sprite[] skins;

    private void OnEnable()
    {
        store1Skin = PlayerPrefs.GetInt("s1Skin");
        store1Shoes = PlayerPrefs.GetInt("s1Shoes");
    }

    private void Start()
    {
        if (store1Skin != 0)
        {
            leftLeg.sprite = skins[store1Skin - 1];
        }

        if (store1Shoes == 0)
        {
            leftShoe.gameObject.SetActive(false);
        }
        else
        {
            if (store1Shoes == 5)
            {
                leftShoe.GetComponent<RectTransform>().localPosition = new Vector3(leftShoe.GetComponent<RectTransform>().localPosition.x + 60.5f, leftShoe.GetComponent<RectTransform>().localPosition.y);
            }

            leftShoe.sprite = skins[store1Shoes - 1];
        }

        int botSkin = Random.Range(0, 5);
        int botShoes = Random.Range(5, 9);

        if (botSkin != 0)
        {
            rightLeg.sprite = skins[botSkin - 1];
        }

        if (botShoes == 9)
        {
            rightShoe.gameObject.SetActive(false);
        }
        else
        {
            if (botShoes == 5)
            {
                rightShoe.GetComponent<RectTransform>().localPosition = new Vector3(rightShoe.GetComponent<RectTransform>().localPosition.x + 60.5f, rightShoe.GetComponent<RectTransform>().localPosition.y);
            }

            rightShoe.sprite = skins[botShoes - 1];
        }
    }
}
