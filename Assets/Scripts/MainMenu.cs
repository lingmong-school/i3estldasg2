using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Author:Rayn Bin Kamaludin
* Date:12/6/2024
* Description: Menu screen handler
*/

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(0); // Start game
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit game
    }
}
