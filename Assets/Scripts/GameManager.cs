using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;
    private bool gameIsPaused = false;
    private float defaultFixedDeltaTimeValue;

    void Start()
    {
        defaultFixedDeltaTimeValue = Time.fixedDeltaTime;
    }
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        //if (CrossPlatformInputManager.GetButton("Pause"))
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gameIsPaused)
            {
                PauseGame();
                gameIsPaused = true;
            }
            else
            {
                UnPauseGame();
                gameIsPaused = false;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = defaultFixedDeltaTimeValue;
    }
}
