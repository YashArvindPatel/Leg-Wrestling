using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel, menuPanel;

    public void BackButtonClicked()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void SoundButtonClicked()
    {
        FindObjectOfType<SoundOnOff>().Toggle();
    }

    public void MusicButtonClicked()
    {
        FindObjectOfType<MusicOnOff>().Toggle();
    }
}
