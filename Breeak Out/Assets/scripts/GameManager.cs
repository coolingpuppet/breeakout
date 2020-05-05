using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Lives;
    public int score;
    public Text livestext;
    public Text scoretext;
 
    // Start is called before the first frame update
    void Start()
    {
        livestext.text = "HP " + Lives;
        scoretext.text = "Score " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives( int changeInLives)
    {
        Lives += changeInLives;

        // check for no lives left and trigger the end of the game.

        livestext.text = "HP " + Lives;

    }
    public void UpdateScore(int points)
    {
        score += points;
        scoretext.text = "Score " + score;
    }
}
