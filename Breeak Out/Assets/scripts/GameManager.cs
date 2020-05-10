using System.Collections;
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
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;

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

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level00");
    }

    public void Quit()
    {
        Application.Quit ();
        Debug.Log("Game Quit");
    }
    
    
}
