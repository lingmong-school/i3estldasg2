using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance => instance;
    public FirstPersonController firstPersonController;
    public HealthBarManager health;
    public PlayerInventory playerInventory;

    void Awake()
    {
        // Check if an instance of this object already exists
        if (instance != null && instance != this)
        {
            // If it does, destroy the new instance
            Destroy(gameObject);
        }
        else
        {
            // If it doesn't, set this as the instance and make it persistent
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-establish references to objects in the new scene here
        if (scene.name == "Menu")
        {
            Destroy(gameObject);
        }
        else
        {
            UpdateReferences();
        }
   
    }

    public void UpdateReferences()
    {
        // Find and set references to necessary objects in the new scene
        // Example:
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Re-establish references related to the player
        }

        var healthBar = GameObject.Find("HealthBar");
        if (healthBar != null)
        {
            // Re-establish references related to the health bar
        }
    }
}
