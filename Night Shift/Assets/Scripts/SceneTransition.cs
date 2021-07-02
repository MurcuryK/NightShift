using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    CharacterController controller;

    private bool sound = false;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the players controller
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // If it collides with the elevator
        if (hit.gameObject.tag == "Lift")
        {
            
            sound = true;
            controller.GetComponent<Movement>().enabled = false;
            Debug.Log("Work");
            // Calls function
            StartCoroutine(Wait());
            controller.GetComponent<Movement>().enabled = true;
        }
    }




    IEnumerator Wait() //Adds 1 second wait
    {

        // Adds a time delay
        yield return new WaitForSeconds(1);
        // Loads the next scene from the scene Manager
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
