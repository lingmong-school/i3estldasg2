using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunDamage : MonoBehaviour
{
    public float Damage;
    public Transform PlayerCamera; // Define PlayerCamera
    public float BulletRange = 100f; // Define BulletRange with a default value

    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
                Debug.Log("Damage taken");
            }
        }
    }
}
