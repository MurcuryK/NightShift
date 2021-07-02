using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// use the follwing video for referance https://www.youtube.com/watch?v=ne41wItQmdo&t=170s
public class ObjectiveList : MonoBehaviour
{
    [SerializeField]
    bool Objective_Show = false;
    [SerializeField]
    Texture Player_Objective;
    [SerializeField]
    private int Collision;
    public GameObject obj_1;
    // Start is called before the first frame update
    void Start()
    {
        Objective_Show = false;
        obj_1.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Objective_Show == false && Collision == 0)
            Objective_Show = true;

        //Debug.Log(" works");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Objective_Show = false;

        Collision = 1;
    }
    // Update is called once per frame

    void OnGUI()
    {
        // sets obj_1 to true 
        if (Objective_Show == true)
        {
            obj_1.SetActive(true);
        }
    }
    void Update()
    {
        // if the player touches the button then true 
        if (Input.GetButtonDown("ShowOjective") && Collision == 1)
        {
            Objective_Show = true;
        }
        //if the player lets go of the button then false
        else if (Input.GetButtonUp("ShowOjective") && Collision == 0)
        {
            Objective_Show = false;
        }
    }
}
