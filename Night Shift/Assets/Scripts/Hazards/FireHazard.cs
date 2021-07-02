using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHazard : MonoBehaviour
{
    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller
    Score score;

    int hazard = -10; //hazard penalty
    int fixedHazard = 10;//reward for remobal of hazard

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController"); //finds the gamecontroller object
        gController = gameController.GetComponent<GameController>(); //gets the gameController script component from the GameController game object and records it as gController
        score = gameController.GetComponent<Score>(); //gets the score script
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireExtinguisher")) //checks if it is the fire extinguisher
        {
            score.AddScore(fixedHazard); //increases the players score
            Destroy(gameObject); //kills the fire
            gController.StartCoroutine(gController.showMessage("Fire Extinguished.", 2)); //tells the gamecontroller to run the message
        }

        if (other.CompareTag("Player")) //checks if it is the player
        {
            score.AddScore(hazard); //decreases the players score
            gController.StartCoroutine(gController.showMessage("It is too dangerous to go closer to the fire. I need something to put it out with.", 3)); //plays the message
        }
    }

}
