using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Player death handler
*/

public class Dead : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    public void ReturnMenu()
    {
        SceneManager.LoadScene(0); // Load menu
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
