using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Author:Rayn Bin Kamaludin
* Date:13/6/2024
* Description: Medkit handler
*/
public class MedKit : MonoBehaviour
{
    public AudioClip healSound; // Sound effect for healing

    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make MedKit spin
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0);
    }

    // Make MedKit disappear and play heal sound
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.health.Heal(2);
            PlayHealSound();
            HideMedKit();
        }
    }

    private void PlayHealSound()
    {
        if (healSound != null)
        {
            audioSource.PlayOneShot(healSound);
        }
    }

    private void HideMedKit()
    {
        // Disable the MedKit's visual and physical components
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Destroy the MedKit after the sound has finished playing
        Destroy(gameObject, healSound.length);
    }
}
