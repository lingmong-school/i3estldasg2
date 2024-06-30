using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*
* Author:Rayn Bin Kamaludin
* Date:29/6/2024
* Description: Objects that can be shot at
*/
public class Entity : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

    private DoorFacility doorFacility;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            if (health <= 0f)
            {
                if (doorFacility != null)
                {
                    doorFacility.EnemyDestroyed(GetComponent<Collider>());
                }
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        doorFacility = FindObjectOfType<DoorFacility>();
        Health = StartingHealth;
    }
}