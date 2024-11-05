using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float shootDirection = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDirection > 0)
            return 1; // shoot right 
        else return -1; // shoot left
            
        
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        OnHitWith(other.GetComponent<Character>());
    }
}
