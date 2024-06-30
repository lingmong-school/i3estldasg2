using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Damage handler for objects
*/
public class EnvironmentDamage : MonoBehaviour
{
    public float damageCooldown = 0.35f; // Cooldown period in seconds
    private bool canDamage = true; // Flag to control damage cooldown

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            GameManager.instance.health.TakeDamage(2);
            StartCoroutine(DamageCooldownCoroutine()); // Start the cooldown coroutine
        }
    }

    private IEnumerator DamageCooldownCoroutine()
    {
        canDamage = false; // Disable further damage
        yield return new WaitForSeconds(damageCooldown); // Wait for the cooldown period
        canDamage = true; // Enable damage again
    }
}
