using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Spawning enemies in the center
*/

public class EnemySpawn : MonoBehaviour
{
    public AudioClip attackSound; // The sound effect to play when attacking
    public GameObject enemies;
    public AudioSource audioSource; // Reference to the AudioSource component


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (attackSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(attackSound);
            }
            enemies.SetActive(true);
        }
    }
}
