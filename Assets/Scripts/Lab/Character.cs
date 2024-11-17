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
        
        if (health <= 0)
        {
            Destroy(gameObject);  // Destroy this GameObject when health is zero or below
            return true;  // Return true since the object is dead
        }
        return false;  // Otherwise, return false
    }
    public void TakeDamage(int damage)
    {

        health -= damage;
        
        UpdateHealthSlider();

        IsDead();   
        
    }

    public void Init(int newHealth)
    {
        maxHealth = newHealth;      
        health = newHealth;         
        healthSlider.maxValue = newHealth;  
        healthSlider.value = newHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

     protected virtual void HealthStart()
     {
        maxHealth = 100;
        health = maxHealth;
        UpdateHealthSlider();  
        
     }


    // Method to update the health slider UI
    public void UpdateHealthSlider()
    {
        
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        
    }
}
