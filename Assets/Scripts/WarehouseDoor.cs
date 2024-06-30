using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarehouseDoor : MonoBehaviour
{
    public Vector3 targetPosition; // Set this in the Inspector to the desired teleport location
    private static GameObject playerInstance;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Store the player's game object
            GameObject player = other.gameObject;

            // Load the new scene and teleport the player
            StartCoroutine(LoadSceneAndTeleportPlayer(player));
        }
    }

    private IEnumerator LoadSceneAndTeleportPlayer(GameObject player)
    {
        // Load the new scene asynchronously
        UnityEngine.AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        // Wait until the scene has fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Ensure GameManager re-establishes its references
        GameManager.Instance.UpdateReferences();

        // Check if there's already a player instance in the new scene
        if (playerInstance != null)
        {
            Destroy(playerInstance);
        }

        // Set the player instance to the current player and make it persistent
        playerInstance = player;
        DontDestroyOnLoad(playerInstance);

        // Teleport the player to the target position
        player.transform.position = targetPosition;
    }
}
