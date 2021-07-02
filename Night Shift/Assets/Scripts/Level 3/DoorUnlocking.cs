using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlocking : MonoBehaviour
{

    public bool isActive = false;
    public bool gotKey = false;
    public GameObject key;
    public GameObject unlockDoor;
    GameObject cube;

    public GameObject player;
    public float distanceDoor;
    public float distanceKey;


    //putting messages to player through game controller
    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gController = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceKey = Vector3.Distance(key.transform.position, player.transform.position); // Gets the distance to the Key
        distanceDoor = Vector3.Distance(unlockDoor.transform.position, player.transform.position); // Gets the distance to the Door

        if (isActive) //Sets the door to what its lock state is
        {
            unlockDoor.SetActive(false);

        }
        else
        {
            unlockDoor.SetActive(true);

        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Sets up Ray tracing
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (distanceKey <= 2)//Sets the distance to the key
                {
                    if (hit.transform.gameObject == key)
                    {
                        gotKey = true;
                        gController.StartCoroutine(gController.showMessage("Key collected", 3)); //message going though gameController script
                        key.SetActive(false);
                    }
                }
                if (distanceDoor <= 2)//Sets the distance to the door
                {
                    if (hit.transform.gameObject == unlockDoor && gotKey)
                    {
                        isActive = true;
                        gController.StartCoroutine(gController.showMessage("A door has opened", 3));
                    }
                }

            }
        }
    }
}

