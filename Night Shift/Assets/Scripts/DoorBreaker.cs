using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBreaker : MonoBehaviour {

    public GameObject Door;
    public bool isActive = false;
    public Transform theHolder;


    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "DoorBreaker")
        {
            //Finds Colliding gameobject
            GameObject Cube = col.gameObject;

            //Kinematic is turned on
            Cube.GetComponent<Rigidbody>().isKinematic = true;
            //Move to the empty gameoject
            Cube.transform.position = theHolder.position;
            //Makes it a chiled of the empty gameobject
            Cube.transform.parent = GameObject.Find("Holder").transform;

            //Opens F-Door
            Door.SetActive(false);
            isActive = true;


        }


    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "DoorBreaker")
        {
            //Finds Colliding gameobject
            GameObject Cube = col.gameObject;

            //Kinematic is turned on
            Cube.GetComponent<Rigidbody>().isKinematic = false;

            //Closes F-Door
            Door.SetActive(true);
            isActive = false;
        }

    }
}
