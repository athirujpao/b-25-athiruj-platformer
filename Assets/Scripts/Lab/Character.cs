using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;  // Maximum health value
     private int health;           // Current health value

    
    public Slider healthSlider;

    public Animator anim;
    public Rigidbody2D rb;

    public bool IsDead()
    {
        return health <= 0;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        Debug.Log($"{this.name} took {damage} damage; has {health} left");

        UpdateHealthSlider();


        if (IsDead())
        {
            Debug.Log($"{this.name} has died!");  // Debug statement for when character dies
        }
    }

    public void Init(int newHealth)
    {
        maxHealth = newHealth; 
        health = newHealth;

        
            healthSlider.maxValue = newHealth;  // Set the slider's maximum value to the character's max health
            healthSlider.value = newHealth;     // Set current value to be full at the start
        



        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

     protected virtual void HealthStart()
    {
        Init(health);
        UpdateHealthSlider();  // Make sure the health bar starts fully filled
    }


    // Method to update the health slider UI
    private void UpdateHealthSlider()
    {

        healthSlider.maxValue = maxHealth;  // Ensure max value is always up-to-date
        healthSlider.value = health;  // Update the slider to reflect the current health
        Debug.Log($" {this.name} Has health left {health}");
    }
}
