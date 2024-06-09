using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public Transform PlayerCamera;

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
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;
    }
}
