using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*
* Author:Rayn Bin Kamaludin
* Date:12/6/2024
* Description: Gun effect variables
*/
public class GunDamage : MonoBehaviour
{
    public float Damage;
    public float ExplosiveDamage = 1f;
    public Transform PlayerCamera; // Define PlayerCamera
    public float BulletRange = 100f; // Define BulletRange with a default value
    public GameObject impactEffect;
    public float BlastRadius = 2f;
    public float Force = 700f;

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

            //explosion effects
            GameObject impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGO, 2.2f);

            Collider[] colliders = Physics.OverlapSphere(hitInfo.point, BlastRadius);

            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    enemy.Health -= ExplosiveDamage;
                    rb.AddExplosionForce(Force, hitInfo.point, BlastRadius);
                }

            }
        }
    }

    

}