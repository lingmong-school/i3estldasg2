using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Pause menu handler
*/

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;

    void Start()
    {
        // Start with the pause menu deactivated
        pause.SetActive(false);
    }

    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    void OnPause()
    {
        if (pause.activeSelf)
        {
            // If the pause menu is active, deactivate it and resume the game
            pause.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // If the pause menu is not active, activate it and pause the game
            pause.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
