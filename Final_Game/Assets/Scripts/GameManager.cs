using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public static int CurScore;
    public  bool gamePaused;
    public static bool isDoorLocked;
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

    public void ToggleEndGameMenu()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
        GameUI.instance.SetEndGameScreen(true, 15);
        
    }

    public static void AddScore(int score)
    {
        CurScore += score;
        GameUI.instance.UpdateScoreText(CurScore);
    }

    public void WinGame()
    {
        // Show the win screen and score
        GameUI.instance.SetEndGameScreen(true, CurScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }

    public void LoseGame()
    {
        // Load the Lose Screen and score
        GameUI.instance.SetEndGameScreen(false, CurScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}

