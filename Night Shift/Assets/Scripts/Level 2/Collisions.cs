using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller

    // Sets the respawn

    CharacterController controller;
  
    
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");//finds the gameController object
        gController = gameController.GetComponent<GameController>(); //gets the gamecontroller script

        // Gets the players controller
        controller = GetComponent<CharacterController>();
        
    }


    // Checks if the player has collided with anything
    void OnCollisionEnter(Collision collision)
    {

        // If it collides with the Boxes
        if (collision.gameObject.tag == "Boxes")
        {
          //  Debug.Log("Working");
        }

        // If it collides with the hole
        if (collision.gameObject.tag == "Hole")
        {
          //  Debug.Log("Falling?");

            StartCoroutine(Wait());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
        }

       // Debug.Log("AHHHH?");

    }

    IEnumerator Wait() //Adds 1 second wait
    {
        // Debug.Log(":(");
        gController.StartCoroutine(gController.showMessage("You have fall through a pitfall", 2));//runs the message
        controller.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        controller.GetComponent<Movement>().enabled = true;
       // Debug.Log("AHHHH?");
    }

}
