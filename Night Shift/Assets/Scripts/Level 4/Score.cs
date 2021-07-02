using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int score = 200; //the players score
    public Text scoreText; //the score ui text
    static bool gameCompleted = false; //bool used to controll showing the final score upon the completion of the last level
    public bool gComp = false; //used to carry over the gameCompleted bool between scripts due to it being unaccessable

    private void Start()
    {
        gComp = gameCompleted; // sets the gComp to being the same as the game completed bool
        UpdateScore(); //updates the score


    }

    public void AddScore(int scoreValue) //adds a value determined by other scripts to the score
    {
        score += scoreValue; //adds to the score
        UpdateScore(); //updates the score

    }

    //updates the players score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score; //sets the score on the UI
    }

    public void GameCompleted()
    {
        gameCompleted = true; //sets the game as completed for the finalScore on the title screen
    }

    public void ResetScore()
    {
        score = 200; //sets the player score to 200
        gameCompleted = false; //sets the game completion to false
        scoreText.text = "Score: " + score; //sets the score on the UI
        
    }
}
