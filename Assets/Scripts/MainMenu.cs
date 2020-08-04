using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject storePanel;
    public GameObject gameModePanel;

    public void StartButtonClicked()
    {
        gameModePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SettingsButtonClicked()
    {
        settingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShopButtonClicked()
    {
        storePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
