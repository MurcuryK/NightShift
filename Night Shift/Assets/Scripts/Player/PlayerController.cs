using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform theHand;

    public Transform menu;
    public double menuTimer;

    private Rigidbody rb; //records the ridgidbody as rb
    float speed = 10; //records the players speed

    float MouseSensitivity = 15;
    float xAxisClamp = 0;

   // [SerializeField]
    Transform player;

   // [SerializeField]
    Transform fpcamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() //used fixed update to ensure that the speed is indipendant of frame rate makeing the players speed consistant regardless of the power of the computer it is run on
    {
        moveControlls();
        lookControlls();

        if (Input.GetButtonDown("Cancel"))
        {
            pause();
        }
    }



    void moveControlls()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//records the input axis of horixontal to the name move horizontal
        float moveForward = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveForward);//allows the player to move up down left and right
        movement = transform.TransformDirection (movement);
        rb.velocity = movement * speed;
    }

    void lookControlls()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * MouseSensitivity;
        float rotAmountY = mouseY * MouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 rotCamera = fpcamera.transform.rotation.eulerAngles;
        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        rotCamera.x -= rotAmountY;
        rotPlayer.y += rotAmountX;
        rotCamera.z = 0;

        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotCamera.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotCamera.x = 270;
        }

        fpcamera.rotation = Quaternion.Euler(rotCamera);
        player.rotation = Quaternion.Euler(rotPlayer);
    }


    public void pause()
    {


        if (menu.gameObject.activeInHierarchy == false)
        {
            menu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else if (menu.gameObject.activeInHierarchy == true)
        {
            menu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }


    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -4);
        Time.timeScale = 1;
    }

}

