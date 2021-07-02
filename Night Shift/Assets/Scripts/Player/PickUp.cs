using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theHand;
    public float distance;
    public float distToObject = 2;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        theHand = GameObject.Find("Hand").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);
    }

    //When the player clicks
    private void OnMouseDown()
    {
        if (distance <= distToObject)
        {
            //Gravity is turned off
            GetComponent<Rigidbody>().useGravity = false;
            //Move to the empty gameoject
            this.transform.position = theHand.position;
            //Makes it a chiled of the empty gameobject
            this.transform.parent = GameObject.Find("Hand").transform;
        }


    }

    //when you stop clicking
    private void OnMouseUp()
    {
        //Gets rid of parent
        this.transform.parent = null;
        //Add gravity
        GetComponent<Rigidbody>().useGravity = true;
    }

}
