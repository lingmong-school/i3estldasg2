using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date: 12/6/2024
* Description: Ai for enemy 
*/

public class AiTest : MonoBehaviour
{
    
    public float detectionRange = 10f; // Range within which the enemy detects the player
    public float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    public float attackRange = 2f; // Range within which the enemy attacks the player
    public float attackCooldown = 2f; // Cooldown time between attacks
    public AudioClip attackSound; // The sound effect to play when attacking

    private Rigidbody rb;
    private Animator animator;
    private AudioSource audioSource; // Reference to the AudioSource component
    private float lastAttackTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the enemy.");
        }
        if (animator == null)
        {
            Debug.LogError("No Animator found on the enemy.");
        }
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the enemy.");
        }
    }

    private void FixedUpdate()
    {
        if (rb == null || GameManager.instance.firstPersonController.transform.position == null || animator == null || audioSource == null)
        {
            return;
        }

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, GameManager.instance.firstPersonController.transform.position);

        // Check if the player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer > attackRange)
            {
                // Move towards the player
                FollowPlayer();
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
            }
            else if (Time.time > lastAttackTime + attackCooldown)
            {
                // Call the attack function
                AttackPlayer();
                lastAttackTime = Time.time; // Update the last attack time
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
        }
    }

    private void FollowPlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (GameManager.instance.firstPersonController.transform.position - transform.position).normalized;

        // Calculate the new position for the enemy
        Vector3 newPosition = rb.position + directionToPlayer * moveSpeed * Time.fixedDeltaTime;

        // Move the enemy towards the player using Rigidbody
        rb.MovePosition(newPosition);

        // Make the enemy face the player
        Vector3 lookDirection = GameManager.instance.firstPersonController.transform.position - transform.position;
        lookDirection.y = 0; // Keep the enemy upright
        if (lookDirection != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.LookRotation(lookDirection));
        }
    }

    private void AttackPlayer()
    {
        // Add your attack code here
        animator.SetBool("isAttacking", true);
        Debug.Log("Enemy attacks the player!");
        GameManager.instance.health.TakeDamage(1);

        // Play the attack sound
        if (attackSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }

    // Optional: Visualize detection and attack range in the Unity Editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}