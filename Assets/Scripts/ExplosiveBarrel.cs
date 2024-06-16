using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public GameObject explosionEffect; // Prefab for explosion effect
    private Rigidbody rb;
    private bool isExploding = false; // Prevent multiple explosions

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the barrel.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isExploding)
        {
            return;
        }

        // Check if the barrel is moving
        if (rb.velocity.magnitude > 0.5f)
        {
            // Check if the colliding object has the "Enemy" tag
            if (collision.collider.CompareTag("Enemy"))
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        isExploding = true; // Prevent multiple explosions

        // Instantiate explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Apply explosion force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Apply damage to entities (if they have a health script)
            Entity entity = nearbyObject.GetComponent<Entity>();
            if (entity != null)
            {
                entity.Health -= 7; // Adjust damage value as needed
            }
        }

        // Destroy the barrel
        Destroy(gameObject);
    }
}