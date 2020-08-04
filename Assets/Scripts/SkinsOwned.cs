using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsOwned : MonoBehaviour
{
    public bool[] skinsOwned;

    private void OnEnable()
    {
        skinsOwned = new bool[8];

        for (int i = 0; i < skinsOwned.Length; i++)
        {
            if (PlayerPrefs.GetInt("s1Skin" + (i + 1).ToString()) == 1)
            {
                skinsOwned[i] = true;
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < skinsOwned.Length; i++)
        {
            if (skinsOwned[i])
            {
                PlayerPrefs.SetInt("s1Skin" + (i + 1).ToString(), 1);
            }
            else
            {
                PlayerPrefs.SetInt("s1Skin" + (i + 1).ToString(), 0);
            }
        }
    }
}
