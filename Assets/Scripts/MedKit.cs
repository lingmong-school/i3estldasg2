using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public HealthBarManager DamageHeal;  // Call the healthbar
    // Update is called once per frame
    void Update()
    {
        //Make Medkit spin
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0);
    }
    // Make Medkit dissappear
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DamageHeal.Heal(2);
            Destroy(gameObject);
        }
    }
}


