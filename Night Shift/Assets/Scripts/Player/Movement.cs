using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//This video was used to help creat this coded - https://www.youtube.com/watch?v=_QajrabyTJc
public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public Transform menu;
    public GameObject controlsUI;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;

    Vector3 warpPosition = Vector3.zero;
    public int yAxis = 12;
    public bool isFuture = false;
    public bool coolDown = false;

    private ParticleSystem timeFVX;
    private AudioSource AudioWalking;
    public AudioSource AudioPoof;
    public AudioSource AudioPast;
    public AudioSource AudioFuture;


    public void Start()
    {
        timeFVX = GetComponentInChildren<ParticleSystem>();
        AudioWalking = GetComponent<AudioSource>();

    }


    void Update()
    {

        DaveShift(); //Calls the Dave shift power

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //Defines what the ground is
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;    //Resets the velocity          
        }
        //Gets the Inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Sets up the movement
        Vector3 move = transform.right * x + transform.forward * z;

        //Does the movement
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            AudioWalking.Play();
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
            AudioWalking.Stop(); // or Pause()


        
        if (controller.enabled == true) //was getting errors when daveshifting so added this check to see if the controller was active - kai
        {
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime; //Calculates the velocity
            controller.Move(velocity * Time.deltaTime); //Adds velocity
        }
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);           //Allows the player to Jump
        }
        
        if (Input.GetButtonDown("Fire2")) //activates the pause menu
        {
            pause();
        }

        if (Input.GetButtonDown("ShoCtrls"))
        {
            Controls();
        }

        if (Input.GetKey(KeyCode.LeftControl)) //activates the Sprint
        {
            speed = 8f;
        }
        else { speed = 4f; }
    }

    void DaveShift()
    {
        //If Left shift is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            if (isFuture == false && coolDown == false)//Take player Up to the future 
            {
                AudioPast.Stop();
                StartCoroutine(WaitT()); //moved the code over to the wait enumerators so that the visuail effect synched up correctly - kai
                AudioFuture.Play();
}
            if (isFuture == true && coolDown == false)//Take player Down to the future 
            {
                AudioFuture.Stop();
                StartCoroutine(WaitF());
                AudioPast.Play();
            }
        }
    }


    IEnumerator WaitT() //Adds 1 second wait
    {
        coolDown = true;
        timeFVX.Play(); //plays the visuail effect
        controller.enabled = false;

        AudioPoof.Play();// Audio

        yield return new WaitForSeconds(0.7f);//edited the time so it synched up with the vfx better
        transform.position = new Vector3(transform.position.x, transform.position.y + yAxis, transform.position.z);
        yield return new WaitForSeconds(0.7f);

        AudioPoof.Stop();// Stop audio

        controller.enabled = true;
        isFuture = true;
        coolDown = false;
    }

    IEnumerator WaitF() //Adds 1 second wait
    {
        coolDown = true;
        timeFVX.Play();
        controller.enabled = false;

        AudioPoof.Play();// Audio

        yield return new WaitForSeconds(0.7f);
        transform.position = new Vector3(transform.position.x, transform.position.y - yAxis, transform.position.z);
        yield return new WaitForSeconds(0.7f);

        AudioPoof.Stop();// Stop audio

        controller.enabled = true;
        isFuture = false;
        coolDown = false;
    }

    public void Controls()
    {
        if (controlsUI.gameObject.activeInHierarchy == true)
        {
            controlsUI.gameObject.SetActive(false);
        }
        else
        {
            controlsUI.gameObject.SetActive(true);
        }
    }

    public void pause()
    {
        if (menu.gameObject.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.None;
            menu.gameObject.SetActive(true); //sets the pause menu as active
            Time.timeScale = 0; //freezes time
        }
        else if (menu.gameObject.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1; //unfreezes time
            menu.gameObject.SetActive(false); //hides the menu
        }
    }

    //restarts the game
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    //quits the game
    public void quitGame()
    {
        Application.Quit();
    }

    //quits to the main menu
    public void quitToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
