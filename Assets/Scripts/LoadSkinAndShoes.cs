using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSkinAndShoes : MonoBehaviour
{
    private int store2P1Skin = 0;
    private int store2P1Shoes = 0;
    private int store2P2Skin = 0;
    private int store2P2Shoes = 0;

    public Image leftLeg, leftShoe, rightLeg, rightShoe;

    public Sprite[] skins;

    private void OnEnable()
    {
        store2P1Skin = PlayerPrefs.GetInt("s2P1Skin");
        store2P1Shoes = PlayerPrefs.GetInt("s2P1Shoes");
        store2P2Skin = PlayerPrefs.GetInt("s2P2Skin");
        store2P2Shoes = PlayerPrefs.GetInt("s2P2Shoes");
    }

    private void Start()
    {
        if (store2P1Skin != 0)
        {
            leftLeg.sprite = skins[store2P1Skin - 1];
        }
        
        if (store2P1Shoes == 0)
        {
            leftShoe.gameObject.SetActive(false);
        }
        else
        {
            if (store2P1Shoes == 5)
            {
                leftShoe.GetComponent<RectTransform>().localPosition = new Vector3(leftShoe.GetComponent<RectTransform>().localPosition.x + 60.5f, leftShoe.GetComponent<RectTransform>().localPosition.y);
            }

            leftShoe.sprite = skins[store2P1Shoes - 1];
        }  
        
        if (store2P2Skin != 0)
        {
            rightLeg.sprite = skins[store2P2Skin - 1];
        }

        if (store2P2Shoes == 0)
        {
            rightShoe.gameObject.SetActive(false);
        }
        else
        {
            if (store2P2Shoes == 5)
            {
                rightShoe.GetComponent<RectTransform>().localPosition = new Vector3(rightShoe.GetComponent<RectTransform>().localPosition.x + 60.5f, rightShoe.GetComponent<RectTransform>().localPosition.y);
            }

            rightShoe.sprite = skins[store2P2Shoes - 1];
        }    
    }
}
