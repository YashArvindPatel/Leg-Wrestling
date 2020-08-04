using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject menuPanel, store1Panel, store2Panel;

    public void BackButtonClicked()
    {     
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnePlayerClicked()
    {
        store1Panel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void TwoPlayersClicked()
    {
        store2Panel.SetActive(true);
        gameObject.SetActive(false);
    }
}
