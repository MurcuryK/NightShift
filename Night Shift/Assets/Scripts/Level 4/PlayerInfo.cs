using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public string info; //what the message says, to be input in the editor
    public int time; //how long the message remains for

    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");//gets the gameController object
        gController = gameController.GetComponent<GameController>();//gets the gameController Script
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//checks if it is the player
        {
            gController.StartCoroutine(gController.showMessage(info, time)); //tells the game controller to send this message and remove it after this time
            Destroy(gameObject); //destroys the object so the message only fires once
        }
    }
}
