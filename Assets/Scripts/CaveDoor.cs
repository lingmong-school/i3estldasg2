using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Teleport player after exiting cave
*/

public class CaveDoor : MonoBehaviour
{
    public Vector3 targetPosition; // Set this in the Inspector to the desired teleport location
    private static GameObject playerInstance;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
