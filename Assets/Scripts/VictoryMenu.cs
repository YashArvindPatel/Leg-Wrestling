using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public AudioClip failClip, winnerClip;

    private int winner = 1;

    public void SetWinner(int winner)
    {
        this.winner = winner;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (FindObjectOfType<GameManagementSinglePlayer>().GetSoundOn())
            {
                if (winner == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(winnerClip);
                }
                else if (winner == 2)
                {
                    GetComponent<AudioSource>().PlayOneShot(failClip);
                }
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (FindObjectOfType<GameManagement>().GetSoundOn())
            {
                GetComponent<AudioSource>().PlayOneShot(winnerClip);
            }
        }     
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
