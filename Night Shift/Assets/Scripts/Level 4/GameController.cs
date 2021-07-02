using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float startTime; //records the players time
    public Text timerText; //displayes the players time on the ui

    GameObject player; //the player

    int sceneNumber; //the scene number

    public bool Paycheck = false; //paycheck bool
    public bool deskKey = false; //key bool
    public bool mop = false; //mop bool

    public Text gameInfoText; //the hints UI
    public Text objectiveText; //the player objective UI

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene(); //records the active scene
        sceneNumber = scene.buildIndex; //records the scenes build number
        //sets the objective text as a particular message depending on what the level is
        if (sceneNumber <= 1) 
        {
            objectiveText.text = "Find the Vent to escape to the next room";
        }
        if (sceneNumber == 2)
        {
            objectiveText.text = "Get through the vent and take the elevator to the next floor";
        }
        if (sceneNumber == 3)
        {
            objectiveText.text = "Explore the maze to find the elevator to the next floor";
        }
        if (sceneNumber == 4)
        {
            objectiveText.text = "Find keys to unlock the door and escape the server room via the elevator";
        }
        if (sceneNumber == 5)
        {
            objectiveText.text = "Collect your final paycheck from your bosses desk";
        }

        startTime = Time.time; //sets the time 

        player = GameObject.FindGameObjectWithTag("Player"); //finds an object tagged with player and records it as player




    }

    void Update()
    {
        float t = Time.time - startTime; //records the players time as time.time = the starting time
        string mins = ((int)t / 60).ToString("00");  // devides the time by 60 and records as a string
        string sec = (t % 60).ToString("00"); //gets the remainder of the time being devided by 60 and converts it into a string
        timerText.text = mins + ":" + sec; //displayes the time on the ui as mins and seconds

    }

    public IEnumerator showMessage(string message, float delay) //displays timed messges to the player
    {

        gameInfoText.text = message; //sets the in UI text as the message
        gameInfoText.enabled = true; //enables the text UI
        yield return new WaitForSeconds(delay); //waits for the time input
        gameInfoText.enabled = false; //disables the text UI
    }



}
