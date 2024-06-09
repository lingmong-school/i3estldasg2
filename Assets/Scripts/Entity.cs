using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

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
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        Health = StartingHealth;
    }
}
