using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{

     GameObject Visable;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the objects child and calls it visable
        Visable = transform.Find("Collapsed Floor").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionStay(Collision collision)
    {
        // If it collides with the Boxes
        if (collision.gameObject.tag == "Boxes")
        {
            Visable.SetActive(true);
         //   Debug.Log("Sitting");
        }
        else
        {
         //   Debug.Log("Exists");
            Visable.SetActive(false);
          //  Debug.Log("No more");
        }
    }
}
