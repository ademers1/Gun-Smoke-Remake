using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject canvas;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                
            }
            else
            {
                Time.timeScale = 1;
              
            }
        }      
    }
}

