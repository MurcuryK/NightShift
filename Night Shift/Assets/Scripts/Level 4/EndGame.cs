using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    
    GameObject gameController; //records a game object as gameController
    GameController gController; //game controller script
    Score score; //score script


    private void Start()
    {

        gameController = GameObject.FindGameObjectWithTag("GameController"); //finds the game controller object
        gController = gameController.GetComponent<GameController>(); //gets the game controller script
        score = gameController.GetComponent<Score>(); //gets the score script
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & gController.Paycheck == true) //checks if the player is in the trigger and if the player has collected the paycheck
        {
            score.GameCompleted(); //runs the game completed function
            SceneManager.LoadScene(0); //loads the title scene


        }
    }
}
