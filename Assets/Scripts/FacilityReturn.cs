using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Teleport player after exiting facility
*/

public class FacilityReturn : MonoBehaviour
{
    public Vector3 teleportPosition = new Vector3(586f, 7f, 568f);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
            SceneManager.LoadScene(4); // Load the target scene
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 4) // Ensure the correct scene is loaded
        {
            GameManager.instance.firstPersonController.transform.position = teleportPosition; // Teleport the player
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the event
        }
    }
}
