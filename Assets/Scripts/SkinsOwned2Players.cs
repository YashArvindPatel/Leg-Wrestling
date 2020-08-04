using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsOwned2Players : MonoBehaviour
{
    public bool[] firstPlayerSkins;
    public bool[] secondPlayerSkins;

    private void OnEnable()
    {
        firstPlayerSkins = new bool[8];
        secondPlayerSkins = new bool[8];

        for (int i = 0; i < firstPlayerSkins.Length; i++)
        {
            if (PlayerPrefs.GetInt("s2P1Skin" + (i + 1).ToString()) == 1)
            {
                firstPlayerSkins[i] = true;
            }
        }

        for (int i = 0; i < secondPlayerSkins.Length; i++)
        {
            if (PlayerPrefs.GetInt("s2P2Skin" + (i + 1).ToString()) == 1)
            {
                secondPlayerSkins[i] = true;
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < firstPlayerSkins.Length; i++)
        {
            if (firstPlayerSkins[i])
            {
                PlayerPrefs.SetInt("s2P1Skin" + (i + 1).ToString(), 1);
            }
            else
            {
                PlayerPrefs.SetInt("s2P1Skin" + (i + 1).ToString(), 0);
            }
        }

        for (int i = 0; i < secondPlayerSkins.Length; i++)
        {
            if (secondPlayerSkins[i])
            {
                PlayerPrefs.SetInt("s2P2Skin" + (i + 1).ToString(), 1);
            }
            else
            {
                PlayerPrefs.SetInt("s2P2Skin" + (i + 1).ToString(), 0);
            }
        }
    }
}
