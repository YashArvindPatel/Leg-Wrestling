using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour
{
    private bool musicOn = true;
    public Sprite onSprite, offSprite;
    public GameObject circle;
    public AudioSource audioSource;

    public void Toggle()
    {
        if (musicOn)
        {
            musicOn = false;
            FindObjectOfType<SoundAndMusic>().SetMusicOn(musicOn);
            audioSource.Stop();
            GetComponent<Image>().sprite = offSprite;
            transform.localScale = new Vector3(0.0471555f, 0.05988f, 0.05988f);
            circle.SetActive(true);
        }
        else
        {
            musicOn = true;
            FindObjectOfType<SoundAndMusic>().SetMusicOn(musicOn);
            audioSource.Play();
            GetComponent<Image>().sprite = onSprite;
            transform.localScale = new Vector3(0.135f, 0.135f, 0.135f);
            circle.SetActive(false);
        }
    }
}
