using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    public Transform CaseOpen;

    GameObject gameController; //records a game object as gameController
    GameController gController; //records the gameController script as Gcontroller

  //  public Text objectiveText; //the player objective UI

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController"); //finds the gameController object
        gController = gameController.GetComponent<GameController>(); //gets the gameController script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PadLock"))
        {
            //    CaseOpen.Rotate(new Vector3(0, 0, -180), Space.World);

            gController.objectiveText.text = "Use the code 7481 to unlock the vent and escape";
            gController.StartCoroutine(gController.showMessage("Vent Code Revealed 7481, Objective updated", 9)); //runs the message
          //  Destroy(other.gameObject);
          Destroy(other.gameObject);
        }
    }

}
