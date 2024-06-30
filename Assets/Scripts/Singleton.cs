using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    void Awake()
    {
        // Check if an instance of this object already exists
        if (instance != null && instance != this)
        {
            // If it does, destroy the new instance
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            // If it doesn't, set this as the instance and make it persistent
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}