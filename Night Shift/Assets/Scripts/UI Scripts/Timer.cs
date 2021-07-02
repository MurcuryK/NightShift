using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textTimer;
    private float Timestart;
    // Start is called before the first frame update
    void Start()
    {
        //will give the time from the start of the game 
        Timestart = Time.time;



    }

    // Update is called once per frame
    void Update()
    {
        // stores time when the timer actually started 

       float T = Time.time - Timestart;
        // this stores the minuets of the time
        string minuets = ((int)T / 60).ToString();
        // this stores the seconds of the time
        //f2 Defines that only 2 decimals in the float is wanted 
        string seconds = (T % 60).ToString("f2");
        // Displayes the Time 
        textTimer.text = "Time: " +  minuets + ":" + seconds;




    }
}
