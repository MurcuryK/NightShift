using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    public GameObject[] buttonCount;
    public GameObject[] lightCount;
    public bool[] isActive = new bool[] { false, false, false, false };
    public bool[] currentOrder = new bool[] { false, false, false, false };

    public GameObject lastDoor;
    GameObject cube;

    public GameObject player;

    public AudioSource[] AudioSwitch;


    //im adding referencing the game controller to access the game info system in it - love kai
    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gController = gameController.GetComponent<GameController>();

        currentOrder[0] = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (isActive[0] && isActive[1] && isActive[2] && isActive[3])
        {
            lastDoor.SetActive(false);
            gController.StartCoroutine(gController.showMessage("Shutdown Complete, door overide activated", 3));//messages to the player now go through the game controller

        }
        else
        {
            lastDoor.SetActive(true);

        }
               

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Defines the ray tracing
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.transform.gameObject == buttonCount[0] && currentOrder[0]) //This will check if the button is usable
                {
                    AudioSwitch[0].Play();
                    cube = lightCount[0];
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.green);
                    isActive[0] = true;
                    currentOrder[1] = true;
                    gController.StartCoroutine(gController.showMessage("Server 1 Deactivated", 3)); //Will set the the relevnt light to green and allow for the next switch to be used
                }
                if (hit.transform.gameObject == buttonCount[1] && currentOrder[1])
                {
                    AudioSwitch[1].Play();
                    cube = lightCount[1];
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.green);
                    isActive[1] = true;
                    currentOrder[2] = true;
                    gController.StartCoroutine(gController.showMessage("Server 2 Deactivated", 3)); //Will set the the relevnt light to green and allow for the next switch to be used
                }
                if (hit.transform.gameObject == buttonCount[2] && currentOrder[2])
                {
                    AudioSwitch[2].Play();
                    cube = lightCount[2];
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.green);
                    isActive[2] = true;
                    currentOrder[3] = true;
                    gController.StartCoroutine(gController.showMessage("Server 3 Deactivated", 3)); //Will set the the relevnt light to green and allow for the next switch to be used
                }
                if (hit.transform.gameObject == buttonCount[3] && currentOrder[3])
                {
                    AudioSwitch[3].Play();
                    cube = lightCount[3];
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.green);
                    isActive[3] = true;
                    gController.StartCoroutine(gController.showMessage("Server 4 Deactivated", 3)); //Will set the the relevnt light to green and allow for the next switch to be used
                }
            }
        }

    }



}
