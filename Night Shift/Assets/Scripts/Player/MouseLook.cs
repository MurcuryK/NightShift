using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This video was used to help creat this coded - https://www.youtube.com/watch?v=_QajrabyTJc
public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 200f;
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Hides and locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the Mouse X and Y inputs and adds sensitivity to them
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;                                                            //Y rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //Makes it so Y roation can not go to far

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);                  //Sets X rotation 
        playerBody.Rotate(Vector3.up * mouseX);                                         //Sets X rotation for body

    }
}
