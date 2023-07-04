using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame = false;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject pnlEndGame, pnlStart;
    public Text txtEndPoint;
    public Button btnReplay, btnStart;

    public object Birdanim { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
        pnlStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime == true)
            {
                startGame();
                
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                pnlStart.SetActive(false);
            }
        }
    }

    public void getPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void replayGame()
    {
        startGame();
    }
    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;

        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your Point: " + gamePoint.ToString();
    }
}
