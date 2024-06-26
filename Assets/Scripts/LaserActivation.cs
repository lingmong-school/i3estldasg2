using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivation : MonoBehaviour
{
    public float activeDuration = 2f; // Duration the laser is active
    public float inactiveDuration = 0.5f; // Duration the laser is inactive
    private bool isActive = true; // Tracks if the laser is currently active
    private float timer; // Timer to track the elapsed time
    private GameObject triggerObject;

    void Start()
    {
        triggerObject = transform.GetChild(0).gameObject; // Assuming the trigger object is the first child
        ActivateLaser();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isActive && timer >= activeDuration)
        {
            DeactivateLaser();
            isActive = false;
            timer = 0f;
        }
        else if (!isActive && timer >= inactiveDuration)
        {
            ActivateLaser();
            isActive = true;
            timer = 0f;
        }
    }

    private void ActivateLaser()
    {
        triggerObject.SetActive(true);
    }

    private void DeactivateLaser()
    {
        triggerObject.SetActive(false);
    }
}