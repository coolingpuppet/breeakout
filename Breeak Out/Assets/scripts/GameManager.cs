﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives;
    public int score;
    public Text livestext;
    public Text scoretext;
    public Text highScoretext;
    public InputField highscoreInput;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public BallScript script;
    
    

    public bool gameover;
    public int numberofBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        livestext.text = "HP " + Lives;
        scoretext.text = "Score " + score;
        numberofBricks = GameObject.FindGameObjectsWithTag("bricks").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives( int changeInLives)
    {
        Lives += changeInLives;

        // check for no lives left and trigger the end of the game.
        if (Lives <= 0)
        {
            Lives = 0;
            GameOver();

        }

        livestext.text = "HP " + Lives;

    }
    public void UpdateScore(int points)
    {
        score += points;
        scoretext.text = "Score " + score;
    }

    public void UpdateNumberofBricks()
    {
        numberofBricks --;
        
        if (numberofBricks <= 0)
        {
            if (currentLevelIndex >= levels.Length -1 )
            {
                GameOver();
            }
            else
            {
                script = FindObjectOfType<BallScript>();  // to be able to acess ballScript.cs functions from gameManager.cs                                                              
                script.rb.velocity = Vector2.zero;
                script.inPlay = false;
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>(). text = "Loading Level" + (currentLevelIndex+2);
               gameover = true;
               Invoke ("LoadLevel", 3f);
               
            }

        }
    }
    void LoadLevel()
    {
        currentLevelIndex ++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberofBricks = GameObject.FindGameObjectsWithTag("bricks").Length;
        gameover = false;
        loadLevelPanel.SetActive(false);
        
    
    }

    void GameOver ()
    {
        gameover = true;
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            highScoretext.text = "New Highscore " + "\n" + "Enter Your name";
            highscoreInput.gameObject.SetActive(true);
        }
        else
        {
            highScoretext.text = PlayerPrefs.GetString ("HIGHSCORENAME") +"'s" + " Highscore was " + highScore + "\n" + "You can beat it";

        }
    

    }

    public void NewHighScore()
    {
        string highScoreName = highscoreInput.text;
        PlayerPrefs.SetString ("HIGHSCORENAME", highScoreName);
        highscoreInput.gameObject.SetActive(false);
        highScoretext.text ="Congratulations "+ highScoreName + "\n" + "Your New Highsocre " + score;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level00");
    }

    public void Quit()
    {
        SceneManager.LoadScene("menu");
        
    }
    
    
}
