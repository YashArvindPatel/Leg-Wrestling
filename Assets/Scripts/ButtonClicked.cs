using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClicked : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void ButtonIsClicked()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (FindObjectOfType<SoundAndMusic>().GetSoundOn())
            {               
                audioSource.PlayOneShot(audioClip);           
            }
        }   
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (FindObjectOfType<GameManagementSinglePlayer>().GetSoundOn() && FindObjectOfType<GameManagementSinglePlayer>().GetStartGame())
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (FindObjectOfType<GameManagement>().GetSoundOn() && FindObjectOfType<GameManagement>().GetStartGame())
            {
                audioSource.PlayOneShot(audioClip);
            }
        }

    }
}
