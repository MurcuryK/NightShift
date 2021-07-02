using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// use the follwing video for referance https://www.youtube.com/watch?v=ne41wItQmdo&t=170s
public class CodeLock : MonoBehaviour
{
    // stores the lengh of code 
    int LenghtOfCode;
    // tells the position of the code 
    int PositionInCode;

    // stores the actual code 
    public string Code = "";
    // stores the attempted code 
    public string CodeAttempt = "";
    // this method will check the code is correct
    public Transform VentOpen;

    private void Start()
    {
        // allows the code lenght to automatically set its self to the correct lenght
        LenghtOfCode = Code.Length;
    }
    void Check_Code()
    {
       if(CodeAttempt == Code)
        {
            StartCoroutine(OpenVent());

        }
       else
        {
            Debug.Log("Incorrect Code");
        }
    }

    IEnumerator OpenVent()
    {
        // rotates the Ventdoor 90 degrees in world space
        VentOpen.Rotate(new Vector3(0, -90, 0), Space.World);

        yield return new WaitForSeconds(4);
        VentOpen.Rotate(new Vector3(0, 90, 0), Space.World);
    }
 
    public void SetValue (string value)
    {
        PositionInCode++;
        if(PositionInCode <= LenghtOfCode)
        {
            CodeAttempt += value;
        }


        if(PositionInCode == LenghtOfCode)
        {
           //calls the check code function 
            Check_Code();

            CodeAttempt = "";
            PositionInCode = 0;
        }


    }

    
}
