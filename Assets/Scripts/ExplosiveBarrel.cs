using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public GameObject explosionEffect; // Prefab for explosion effect
    public AudioClip explosionSound; // Sound effect for the explosion

    private Rigidbody rb;
    private bool isExploding = false; // Prevent multiple explosions
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

        // Play explosion sound
        if (explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        // Apply explosion force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody nearbyRb = nearbyObject.GetComponent<Rigidbody>();
            if (nearbyRb != null)
            {
                nearbyRb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Apply damage to entities (if they have a health script)
            Entity entity = nearbyObject.GetComponent<Entity>();
            if (entity != null)
            {
                entity.Health -= 7; // Adjust damage value as needed
            }
        }

        // Disable the barrel's visual and physical components
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        rb.isKinematic = true;

        // Destroy the barrel after the sound has finished playing
        Destroy(gameObject, explosionSound.length);
    }
}