using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamage : MonoBehaviour
{
    public HealthBarManager DamageReduction;
    public float damageCooldown = 0.35f; // Cooldown period in seconds
    private bool canDamage = true; // Flag to control damage cooldown

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            DamageReduction.TakeDamage(1);
            canDamage = false; // Disable further damage
            Invoke("ResetDamage", damageCooldown); // Schedule the ResetDamage method to be called after the cooldown period
        }
    }

    private void ResetDamage()
    {
        canDamage = true; // Enable damage again
    }
}
