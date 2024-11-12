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

        }

    }

    public abstract void OnHitWith(Character character);
    
    

    public abstract void Move();

    public void Init(int _damage,IShootable _owner) 
    {
        Damage = _damage;
        shooter = _owner;
    }


    public int GetShootDirection()  // make player can shoot both
    {
        

         float shootDirection = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.position.x;

         if (shootDirection > 0)

         return 1; // shoot right 
         else return -1; // shoot left
        


    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        // i have a problem with the projectile hitting the owner that shoot
        Character character = other.GetComponent<Character>();

        // Ensure that we only interact with Character objects
        if (character == null)
        {
            return;
        }

        // Avoid damaging the owner of the projectile
        if (shooter != null && character == shooter as Character)
        {
            return; // Do nothing if the collided character is the shooter
        }

        OnHitWith(other.GetComponent<Character>());
        Destroy(other.gameObject, 5f);
    }
}
