using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    GameObject gameController; //gameController object
    GameController gController;//gameController script

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");//finds the gameController object
        gController = gameController.GetComponent<GameController>(); //finds the gameController script

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) //checks it its the player
        {
            if (gameObject.CompareTag("Paycheck"))  //checks if it is the paycheck
            {
                gController.Paycheck = true; //tells the game controller that the player has collected the paycheck
                gController.StartCoroutine(gController.showMessage("Severence Collected.", 2)); //informs the player of the collection
                gController.objectiveText.text = "Escape the building on the elevator"; //updates the players objective
                

                Destroy(gameObject);//destroys the paycheck
            }
            if (gameObject.CompareTag("Key")) //checks if it is the key
            {
                gController.deskKey = true; //tells the game controller that the player has the key
                gController.StartCoroutine(gController.showMessage("Key Collected", 1)); //informs the player that they have the key
                Destroy(gameObject); //kills the key
            }
            if (gameObject.CompareTag("Mop")) //checks if it is the mop
            {
                gController.mop = true; //informs gamecontroller
                gController.StartCoroutine(gController.showMessage("Mop Collected", 1)); //informs player
                Destroy(gameObject); //informs object that it no longer exists yay
            }

        }
    }
}