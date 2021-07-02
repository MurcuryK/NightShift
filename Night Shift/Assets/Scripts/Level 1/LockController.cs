using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// use the follwing video for referance https://www.youtube.com/watch?v=ne41wItQmdo&t=170s
public class LockController : MonoBehaviour
{

    CodeLock CodeLock;

    // the range between the player and the buttons 
    int ButtonRange = 100;
    void Update()
    {
        // checks the button if its hit 
        if(Input.GetMouseButtonDown(0))
        {

            ButtonHitCheck();


        }



    }

    void ButtonHitCheck()
    {
        // uses a raycast to check if the button has been hit 
        RaycastHit Butttonhit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out Butttonhit, ButtonRange))
        {
            CodeLock = Butttonhit.transform.gameObject.GetComponentInParent<CodeLock>();

            if(CodeLock != null)
            {
                string value = Butttonhit.transform.name;
                CodeLock.SetValue(value);
            }
        }
    }

}

