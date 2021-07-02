using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    Score score; //score script
    public GameObject finalScoreUI; //score UI

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; //unlockes the cursor
        score = GetComponent<Score>(); //gets the score script
    }
    private void Update()
    {
        if (score.gComp == true) //checks if the player has completed the game
        {
            finalScoreUI.SetActive(true); //sets the final score UI as true
        }
        else
        {
            finalScoreUI.SetActive(false); //sets the final score UI as false
        }
    }
    public void startGame() //starts the game
    {
        score.ResetScore(); //resets the players score
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the first level
        Time.timeScale = 1; //sets the timescale to 1 incase something odd happens with the pause menu may not be necessary but nothing wrong with being careful

    }

    public void quitGame()
    {
        Application.Quit(); //quits the game
    }
}
