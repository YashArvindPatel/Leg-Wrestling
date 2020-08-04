using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    private bool soundOn = true;
    public Sprite onSprite, offSprite;
    public GameObject circle;
    public AudioSource audioSource;

    public void Toggle()
    {
        if (soundOn)
        {
            soundOn = false;
            FindObjectOfType<SoundAndMusic>().SetSoundOn(soundOn);
            audioSource.enabled = false;
            GetComponent<Image>().sprite = offSprite;
            transform.localScale = new Vector3(0.0471555f, 0.05988f, 0.05988f);
            circle.SetActive(true);       
        }
        else
        {
            soundOn = true;
            FindObjectOfType<SoundAndMusic>().SetSoundOn(soundOn);
            audioSource.enabled = true;
            GetComponent<Image>().sprite = onSprite;
            transform.localScale = new Vector3(0.135f, 0.135f, 0.135f);
            circle.SetActive(false);
        }
    }
}
