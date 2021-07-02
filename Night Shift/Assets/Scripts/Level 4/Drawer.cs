using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour
{

    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller
    Score score;//the score script
    Animator _animator; //the animator

    bool _isInsideTrigger; //is the player inside the collsion box
    bool _isOpen = false;//is the draewer open
    int scoreValue = -10; //hazard penalty

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");//finds the gameController object
        gController = gameController.GetComponent<GameController>(); //gets the gamecontroller script
        score = gameController.GetComponent<Score>(); //gets the score script
        _animator = GetComponent<Animator>(); //gets the animator
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //checks if it is the player
        { 
            _isInsideTrigger = true; //player is inside the trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") //checks if it is the player
        {
            _isInsideTrigger = false;//player is nolonger inside the trigger
            if(_isOpen == true) //checks if the drawer is open
            {
                score.AddScore(scoreValue); //adds the collectables value to the players score
                gController.StartCoroutine(gController.showMessage("Open drawers can be hazardous to others when left unattended.", 3));
               
            }
        }
    }

    private void Update()
    {
        if (_isInsideTrigger ) //is the player inside the trigger
        {
            if (Input.GetButtonDown("Fire1")) //did the player press the interact button
            {
                if (gController.deskKey == true) //dose the player have the key
                {
                    gController.StartCoroutine(gController.showMessage("Used the key to unlock the drawer", 2));//sends through the message
                    _isOpen = !_isOpen; //reverses the is open bool
                    _animator.SetBool("open", _isOpen);//runs the animation
                }
                else 
                {
                    gController.StartCoroutine(gController.showMessage("It's locked. I need a key", 2));//runs the message
                }
                
            }
        }
    }
}
