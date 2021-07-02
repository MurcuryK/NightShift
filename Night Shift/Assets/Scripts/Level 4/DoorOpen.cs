using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller
    Collider c; //colldiers
    Animator _animator; //the animator

    bool _isInsideTrigger; //player is inside trigger
    bool _isOpen = false; //drawer is open

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController"); //finds the gameController object
        gController = gameController.GetComponent<GameController>(); //gets the gameController script
        _animator = GetComponent<Animator>(); //gets the animator
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //checks if it is the player
        {
            _isInsideTrigger = true; //player is inside trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") //checks if it is the player
        {
            _isInsideTrigger = false; //player isnt inside trigger
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_isInsideTrigger)//checks if player is inside trigger
        {
            if (Input.GetButtonDown("Fire1")) //did the player press interact button
            {
                gController.StartCoroutine(gController.showMessage("Used Door", 2)); //runs the message
                _isOpen = !_isOpen; //switches the bool
                _animator.SetBool("open", _isOpen); //runs the animation
                _isInsideTrigger = false; //sets the bool as false
                foreach (Collider c in GetComponents<Collider>()) //finds all the colldiers attached to the object
                {
                    c.enabled = !true; //disables the colliders, had issues with the door and didnt have time to fix it so i just disabled the colldiers.
                }

            }
        }
    }
}
