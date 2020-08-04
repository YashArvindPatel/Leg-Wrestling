using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelection : MonoBehaviour
{
    public GameObject menuPanel;

    public void BackButtonClicked()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnePlayerMode()
    {
        SceneManager.LoadScene(1);
    }

    public void TwoPlayerMode()
    {
        SceneManager.LoadScene(2);
    }
}
