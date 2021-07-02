using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller
    Score score; //score script
    public string info; //what the message says, to be input in the editor

    int hazard = -10; //the hazard penalty
    int fixedHazard = 10; //reward for fixing hazard

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController"); //finds the game controller object
        gController = gameController.GetComponent<GameController>(); //gets the gameController script component from the GameController game object and records it as gController
        score = gameController.GetComponent<Score>(); //gets the score script
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //checks if it is the player
        {
            if(gController.mop == true) //checks if player has collected the mop item
            {
                score.AddScore(fixedHazard); //adds the reward ammount to the players score
                gController.StartCoroutine(gController.showMessage("Water mopped.", 2)); //tells the player that an action has been done
                Destroy(gameObject); //destroys the water
            }
            else
            {
                score.AddScore(hazard); //adds the collectables value to the players score
                gController.StartCoroutine(gController.showMessage(info, 2)); //tells the game controller to send this message and remove it after this time
            }
            
        }
    }

}
