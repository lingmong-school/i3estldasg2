using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: When player succeeds
*/

public class Win : MonoBehaviour
{
    




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.playerInventory.hasPower && GameManager.instance.playerInventory.hasEngine && GameManager.instance.playerInventory.hasHull) // Checking win conditions
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}
