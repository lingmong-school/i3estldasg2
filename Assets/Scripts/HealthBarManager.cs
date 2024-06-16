using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public int maxHealth = 9;
    public int currentHealth;

    public Image healthBarImage; // Reference to the UI Image component
    public Sprite[] healthBarSprites; // Array of health bar sprites

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (currentHealth >= 0 && currentHealth <= maxHealth)
        {
            healthBarImage.sprite = healthBarSprites[currentHealth];
        }
    }

    


}

