using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("Level 1");
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("Level 2");
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("Level 3");
        }
        if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("Level 4");
        }
        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

}
