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
        
        UpdateHealthSlider();

        IsDead();   
        
    }

    public void Init(int newHealth)
    {
        healthSlider.maxValue = newHealth;  // Set the slider's maximum value to the character's max health
  
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

     protected virtual void HealthStart()
     {
        maxHealth = 100;
        health = maxHealth;
          
        
     }


    // Method to update the health slider UI
    public void UpdateHealthSlider()
    {
        
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
            
    }
}
