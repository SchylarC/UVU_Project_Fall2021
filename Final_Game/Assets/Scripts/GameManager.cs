using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    public bool isDoorLocked;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
        GameUI.instance.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;
        GameUI.instance.UpdateScoreText(curScore);
        // Does the player have enough points to win
        if(curScore >= scoreToWin)
            WinGame();
    }

     void WinGame()
    {
        // Show the win screen and score
        GameUI.instance.SetEndGameScreen(true, curScore);
        
    }

    public void LoseGame()
    {
        // Load the Lose Screen and score
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}

