using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsAndShoes : MonoBehaviour
{
    private int store1Skin = 0;
    private int store1Shoes = 0;

    private int store2P1Skin = 0;
    private int store2P1Shoes = 0;
    private int store2P2Skin = 0;
    private int store2P2Shoes = 0;

    public int GetStore1Skin()
    {
        return store1Skin;
    }

    public void SetStore1Skin(int store1Skin)
    {
        this.store1Skin = store1Skin;
    }

    public int GetStore1Shoes()
    {
        return store1Shoes;
    }

    public void SetStore1Shoes(int store1Shoes)
    {
        this.store1Shoes = store1Shoes;
    }

    public int GetStore2P1Skin()
    {
        return store2P1Skin;
    }

    public void SetStore2P1Skin(int store2P1Skin)
    {
        this.store2P1Skin = store2P1Skin;
    }

    public int GetStore2P1Shoes()
    {
        return store2P1Shoes;
    }

    public void SetStore2P1Shoes(int store2P1Shoes)
    {
        this.store2P1Shoes = store2P1Shoes;
    }

    public int GetStore2P2Skin()
    {
        return store2P2Skin;
    }

    public void SetStore2P2Skin(int store2P2Skin)
    {
        this.store2P2Skin = store2P2Skin;
    }

    public int GetStore2P2Shoes()
    {
        return store2P2Shoes;
    }

    public void SetStore2P2Shoes(int store2P2Shoes)
    {
        this.store2P2Shoes = store2P2Shoes;
    }

    private void OnEnable()
    {
        store1Skin = PlayerPrefs.GetInt("s1Skin");
        store1Shoes = PlayerPrefs.GetInt("s1Shoes");

        store2P1Skin = PlayerPrefs.GetInt("s2P1Skin");
        store2P1Shoes = PlayerPrefs.GetInt("s2P1Shoes");
        store2P2Skin = PlayerPrefs.GetInt("s2P2Skin");
        store2P2Shoes = PlayerPrefs.GetInt("s2P2Shoes");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("s1Skin", store1Skin);
        PlayerPrefs.SetInt("s1Shoes", store1Shoes);

        PlayerPrefs.SetInt("s2P1Skin", store2P1Skin);
        PlayerPrefs.SetInt("s2P1Shoes", store2P1Shoes);
        PlayerPrefs.SetInt("s2P2Skin", store2P2Skin);
        PlayerPrefs.SetInt("s2P2Shoes", store2P2Shoes);
    }
}
