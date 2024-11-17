using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{

    protected string Owner;

    protected IShootable shooter;


    //abstract method 

    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }

    }

    public abstract void OnHitWith(Character character);
    
    

    public abstract void Move();

    public void Init(int damage,IShootable Owner) 
    {
        Damage = damage;
        shooter = Owner;
    }


    public int GetShootDirection()  // make player can shoot both
    {
        

         float shootDirection = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.position.x;

         if (shootDirection < 0)

         return 1; // shoot right 
         else return -1; // shoot left
        


    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        
         

        Character character = other.GetComponent<Character>();


        if (character != null)  // Check if the other object is a character
        {
            OnHitWith(character);  // Apply damage to the character
            Destroy(gameObject, 0.1f);  // Destroy the weapon itself after a short delay
        }
    }
}
