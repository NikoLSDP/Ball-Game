using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    public enum gameStatus {
        menu, gameStarted, gamePaused, lvlFinished, gameOver
    }
    [SerializeField]
    private Button btnPlay;
    [SerializeField]
    private Text btnPlayLabel;
    [SerializeField]
    private Text lblGameStatus;

    private gameStatus currentState = gameStatus.menu;
    private bool gameOver = false;
    private bool win = false;
    private bool playing = false;

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }
    public bool Win
    {
        get { return win; }
        set { win = value; }
    }
    public bool Playing
    {
        get { return playing; }
        set { playing = value; }
    }


	void Start () {
        showMenu();
	}
	void showMenu()
    {
        switch (currentState)
        {
            case gameStatus.gameOver:
                btnPlayLabel.text = "Retry";
                lblGameStatus.text = "GAME OVER";
                break;
            case gameStatus.gameStarted:
                btnPlay.gameObject.SetActive(false);
                lblGameStatus.gameObject.SetActive(false);
                break;
            case gameStatus.gamePaused:
                btnPlayLabel.text = "Resume";
                lblGameStatus.text = "GAME PAUSED";
                break;
            case gameStatus.lvlFinished:
                btnPlayLabel.text = "Next Level";
                lblGameStatus.text = "LEVEL FINISHED";
                break;
            case gameStatus.menu:
                lblGameStatus.text = "Press Play to Start";
                btnPlayLabel.text = "Play";
                break;
        }
        if (currentState != gameStatus.gameStarted)
        {
            btnPlay.gameObject.SetActive(true);
            lblGameStatus.gameObject.SetActive(true);
        }
    }
    public void OnClickedBtn()
    {
        switch (btnPlayLabel.text)
        {
            case "Play" :
                currentState = gameStatus.gameStarted;
                playing = true;
                break;
            case "Next Level":
                SceneManager.LoadScene("LV 2", LoadSceneMode.Single);
                currentState = gameStatus.menu;
                break;
            case "Retry":
                currentState = gameStatus.menu;
                SceneManager

        }
        showMenu();
    }
    void SetCurrentState()
    {
        if (gameOver)
        {
            currentState = gameStatus.gameOver;
            playing = false;
        }
        if (Win)
        {
            currentState = gameStatus.lvlFinished;
            playing = false;
        }
        if (Playing)
        {
            currentState = gameStatus.gameStarted;
        }
        showMenu();
    }
    // Update is called once per frame
    void Update () {
        SetCurrentState();
	}
}
