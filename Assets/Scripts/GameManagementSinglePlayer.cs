using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagementSinglePlayer : MonoBehaviour
{
    public GameObject victoryPanel;

    public GameObject instruction1, instruction2, instruction3;

    public GameObject leftArea, rightArea, leftAreaClicked, rightAreaClicked;

    public GameObject leftLeg, rightLeg;

    public GameObject coinIncrement1, coinIncrement2;

    public GameObject[] player1Points;
    public GameObject[] player2Points;

    public Image winnerTitle;

    public Sprite winner1, winner2;

    private bool startGame = false;
    private bool gameOver = false;
    private bool coolDown = false;

    public float instTimer1 = 5f, instTimer2 = 3f, instTimer3 = 3f;

    private int round = 1;

    public float timerPerRound = 20.5f;

    public TextMeshProUGUI timerText;

    public Vector3 leftLegPos, rightLegPos;

    public TextMeshProUGUI player1CoinsText, player2CoinsText;

    private int player1Coins = 0;
    private int player2Coins = 0;

    private int player1ClickCount = 0;
    private int player2ClickCount = 0;

    private int player1Wins = 0;
    private int player2Wins = 0;

    private bool soundOn = true, musicOn = true;

    public float setBotAPM = 8;
    private float botAPM = 8;
    private float botTimer = 0f;

    public bool GetSoundOn()
    {
        return soundOn;
    }

    public bool GetMusicOn()
    {
        return musicOn;
    }

    public bool GetStartGame()
    {
        return startGame;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public bool GetCoolDown()
    {
        return coolDown;
    }

    private void OnEnable()
    {
        player1Coins = PlayerPrefs.GetInt("s1Coins");
        player2Coins = 0;

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundOn = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundOn = false;
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            musicOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 0)
        {
            musicOn = false;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("s1Coins", player1Coins);
    }

    void Start()
    {
        if (!musicOn)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
        }

        leftLegPos = leftLeg.GetComponent<RectTransform>().localPosition;
        rightLegPos = rightLeg.GetComponent<RectTransform>().localPosition;

        player1CoinsText.text = player1Coins.ToString();
        player2CoinsText.text = player2Coins.ToString();

        leftArea.GetComponent<Button>().interactable = false;
        rightArea.GetComponent<Button>().interactable = false;

        int randomChange = Random.Range(0, 4);

        if (randomChange == 0)
        {
            setBotAPM -= 2f;
        }
        else if (randomChange == 1 || randomChange == 2)
        {
            // No change to setBotAPM
        }
        else if (randomChange == 3)
        {
            setBotAPM += 2f;
        }
        
        BotAIHandler();

        StartCoroutine(Instructions());
    }

    IEnumerator Instructions()
    {
        instruction1.SetActive(true);

        yield return new WaitForSeconds(instTimer1);

        instruction1.SetActive(false);
        instruction2.SetActive(true);

        yield return new WaitForSeconds(instTimer2);

        instruction2.SetActive(false);
        instruction3.SetActive(true);

        yield return new WaitForSeconds(instTimer3);

        instruction3.SetActive(false);

        leftArea.GetComponent<Button>().interactable = true;
        rightArea.GetComponent<Button>().interactable = true;

        startGame = true;
    }

    public void ClickedLeftArea()
    {
        if (startGame)
        {
            player1ClickCount++;
            leftAreaClicked.SetActive(true);
            DifferenceBetweenPlayers();
        }
    }

    public void ClickedRightArea()
    {
        if (startGame)
        {
            player2ClickCount++;
            rightAreaClicked.SetActive(true);
            DifferenceBetweenPlayers();
        }
    }

    private void Update()
    {
        if (startGame && !coolDown && !gameOver)
        {
            timerPerRound -= Time.deltaTime;

            if (botTimer < 0)
            {
                ClickedRightArea();
                rightArea.GetComponent<ButtonClicked>().ButtonIsClicked();
                botTimer = 1 / botAPM;
            }
            else
            {
                botTimer -= Time.deltaTime;
            }
        }

        if (timerPerRound >= 0 && Mathf.RoundToInt(timerPerRound) < 10)
        {
            timerText.text = "00:0" + System.Convert.ToInt32(timerPerRound).ToString();
        }
        else if (Mathf.RoundToInt(timerPerRound) >= 10)
        {
            timerText.text = "00:" + System.Convert.ToInt32(timerPerRound).ToString();
        }

        if (!coolDown && timerPerRound < 0)
        {
            RoundOver();
        }
    }

    public void BotAIHandler()
    {
        //----------- Updated Bot Logic -----------

        botTimer = 1 / botAPM;

        int difference = player2Wins - player1Wins;


        if (difference == -2)
        {
            botAPM = setBotAPM;
        }
        else if (difference == -1)
        {
            botAPM = setBotAPM - 1f;
        }
        else if (difference == 0)
        {
            botAPM = setBotAPM - 2f;
        }
        else if (difference == 1)
        {
            botAPM = setBotAPM - 2.25f;
        }
        else if (difference == 2)
        {
            botAPM = setBotAPM - 2.5f;
        }

        botTimer = 1 / botAPM;

        //----------- Original Bot Login -----------

        //int randomChance = 0;
        //int difference = player2Wins - player1Wins;


        //if (difference == -2)
        //{
        //    randomChance = Random.Range(0, 9);
        //}
        //else if (difference == -1)
        //{
        //    randomChance = Random.Range(0, 15);
        //}
        //else if (difference == 0)
        //{
        //    randomChance = Random.Range(0, 21);
        //}
        //else if (difference == 1)
        //{
        //    randomChance = Random.Range(0, 27);
        //}
        //else if (difference == 2)
        //{
        //    randomChance = Random.Range(0, 33);
        //}

        //if (randomChance == 0)
        //{
        //    ClickedRightArea();
        //    rightArea.GetComponent<ButtonClicked>().ButtonIsClicked();
        //}
    }

    public void RoundOver()
    {
        coolDown = true;

        if (player1ClickCount > player2ClickCount)
        {
            player1Wins++;
            SetPoints(1);
            player1Coins += 15;
            player1CoinsText.text = player1Coins.ToString();
            coinIncrement1.SetActive(true);
        }
        else if (player1ClickCount < player2ClickCount)
        {
            player2Wins++;
            SetPoints(2);
            player2Coins += 15;
            player2CoinsText.text = player2Coins.ToString();
            coinIncrement2.SetActive(true);
        }

        if (player1Wins > 2)
        {
            GameOver(1);
        }
        else if (player2Wins > 2)
        {
            GameOver(2);
        }
        else
        {
            StartCoroutine(ResetParameters());
        }

        BotAIHandler();
    }

    public void SetPoints(int player)
    {
        if (player == 1)
        {
            player1Points[player1Wins - 1].SetActive(true);
        }

        if (player == 2)
        {
            player2Points[player2Wins - 1].SetActive(true);
        }
    }

    public void GameOver(int player)
    {
        gameOver = true;

        leftArea.GetComponent<Button>().interactable = false;
        rightArea.GetComponent<Button>().interactable = false;

        victoryPanel.SetActive(true);
        victoryPanel.GetComponent<VictoryMenu>().SetWinner(player);

        if (player == 1)
        {
            winnerTitle.sprite = winner1;
        }
        else if (player == 2)
        {
            winnerTitle.sprite = winner2;
        }
    }

    IEnumerator ResetParameters()
    {
        leftArea.GetComponent<Button>().interactable = false;
        rightArea.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(5);

        leftLeg.GetComponent<RectTransform>().localPosition = leftLegPos;
        rightLeg.GetComponent<RectTransform>().localPosition = rightLegPos;

        leftArea.GetComponent<Button>().interactable = true;
        rightArea.GetComponent<Button>().interactable = true;

        player1ClickCount = player2ClickCount = 0;

        round++;
        timerPerRound = 20.5f;
        coolDown = false;
    }

    public void DifferenceBetweenPlayers()
    {
        int difference = player1ClickCount - player2ClickCount;

        if (difference == 0)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x + 50, leftLegPos.y, leftLegPos.z);

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x - 50, rightLegPos.y, rightLegPos.z);

            BotAIHandler();
        }
        else if (difference == 1)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x + 100, leftLegPos.y + 50, leftLegPos.z);

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x - 50, rightLegPos.y, rightLegPos.z);
            rightLeg.transform.SetAsFirstSibling();

            BotAIHandler();
            if (Random.Range(0,2) == 1){
                botAPM += 0.125f;
            }
        }
        else if (difference == 2)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x + 150, leftLegPos.y + 100, leftLegPos.z);

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x - 50, rightLegPos.y, rightLegPos.z);
            rightLeg.transform.SetAsFirstSibling();

            BotAIHandler();
            if (Random.Range(0,2) == 1)
            {
                botAPM += 0.25f;
            }
        }
        else if (difference == 3)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x + 150, leftLegPos.y + 100, leftLegPos.z);

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x, rightLegPos.y - 175, rightLegPos.z);
            rightLeg.transform.SetAsFirstSibling();

            RoundOver();
        }
        else if (difference == -1)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x + 50, leftLegPos.y, leftLegPos.z);
            leftLeg.transform.SetAsFirstSibling();

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x - 100, rightLegPos.y + 50, rightLegPos.z);

            BotAIHandler();
            if (Random.Range(0, 2) == 1)
            {
                botAPM -= 0.125f;
            }
        }
        else if (difference == -2)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x + 50, leftLegPos.y, leftLegPos.z);
            leftLeg.transform.SetAsFirstSibling();

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x - 150, rightLegPos.y + 100, rightLegPos.z);

            BotAIHandler();
            if (Random.Range(0, 2) == 1)
            {
                botAPM -= 0.25f;
            }
        }
        else if (difference == -3)
        {
            leftLeg.GetComponent<RectTransform>().localPosition = new Vector3(leftLegPos.x, leftLegPos.y - 175, leftLegPos.z);
            leftLeg.transform.SetAsFirstSibling();

            rightLeg.GetComponent<RectTransform>().localPosition = new Vector3(rightLegPos.x - 150, rightLegPos.y + 100, rightLegPos.z);

            RoundOver();
        }
    }
}
