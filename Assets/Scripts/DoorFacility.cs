using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Checking  fior enemies in a area
*/
public class DoorFacility : MonoBehaviour
{
    public Animator DoorAnim;
    private HashSet<Collider> enemiesInZone = new HashSet<Collider>(); // Track enemies in the trigger zone

    void Start()
    {
        DoorAnim.SetBool("Open", false); // Start closed
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInZone.Add(other); // Add the enemy to the set
            DoorAnim.SetBool("Open", false); // Ensure the door is closed when an enemy enters
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInZone.Remove(other); // Remove the enemy from the set
            UpdateDoorState();
        }
    }

    public void EnemyDestroyed(Collider enemyCollider)
    {
        enemiesInZone.Remove(enemyCollider); // Remove the enemy from the set when destroyed
        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (enemiesInZone.Count == 0) // Open the door if no enemies are in the trigger zone
        {
            DoorAnim.SetBool("Open", true);
        }
    }
}
