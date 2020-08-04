using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusic : MonoBehaviour
{
    private bool soundOn = true;
    private bool musicOn = true;

    private bool actionTaken = false;

    public GameObject menuPanel, settingsPanel, storePanel, store1Panel, store2Panel;

    public bool GetSoundOn()
    {
        return soundOn;
    }

    public void SetSoundOn(bool soundOn)
    {
        this.soundOn = soundOn;
    }

    public bool GetMusicOn()
    {
        return musicOn;
    }

    public void SetMusicOn(bool musicOn)
    {
        this.musicOn = musicOn;
    }

    private void OnEnable()
    {      
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundOn = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundOn = false;          

            settingsPanel.SetActive(true);
            FindObjectOfType<SoundOnOff>().Toggle();
            settingsPanel.SetActive(false);
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            musicOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 0)
        {
            musicOn = false;
            settingsPanel.SetActive(true);
            FindObjectOfType<MusicOnOff>().Toggle();
            settingsPanel.SetActive(false);
        }

        if (PlayerPrefs.GetInt("FIRSTTIME", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIME", 0);

            settingsPanel.SetActive(true);
            FindObjectOfType<SoundOnOff>().Toggle();
            settingsPanel.SetActive(false);

            settingsPanel.SetActive(true);
            FindObjectOfType<MusicOnOff>().Toggle();
            settingsPanel.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (soundOn)
        {
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
        } 
        
        if (musicOn)
        {
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
        }
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {              
                if (settingsPanel.activeSelf && !actionTaken)
                {
                    menuPanel.SetActive(true);
                    settingsPanel.SetActive(false);
                    actionTaken = true;
                }
                else if (storePanel.activeSelf && !actionTaken)
                {
                    menuPanel.SetActive(true);
                    settingsPanel.SetActive(false);
                    actionTaken = true;
                }
                else if (store1Panel.activeSelf && !actionTaken)
                {
                    storePanel.SetActive(true);
                    store1Panel.SetActive(false);
                    actionTaken = true;
                }
                else if (store2Panel.activeSelf && !actionTaken)
                {
                    storePanel.SetActive(true);
                    store2Panel.SetActive(false);
                    actionTaken = true;
                }
                else if (menuPanel.activeSelf && !actionTaken)
                {
                    PlayerPrefs.SetInt("sound", 1);
                    PlayerPrefs.SetInt("music", 1);

                    Application.Quit();
                }

                actionTaken = false;

                return;
            }
        }
    }
}
