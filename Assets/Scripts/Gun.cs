using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public Transform PlayerCamera;
    public ParticleSystem MuzzleFlash;
    public AudioSource shootingSound; // Reference to the AudioSource component

    // By default gun is semi
    public bool Automatic;

    private float CurrentCooldown;

    void Start()
    {
        PlayerCamera = Camera.main.transform;
        CurrentCooldown = FireCooldown;
    }

    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else // Semi-automatic mode
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    MuzzleFlash.Play();
                    OnGunShoot?.Invoke();
                    shootingSound.Play(); // Play the shooting sound
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }
}