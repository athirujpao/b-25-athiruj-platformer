using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected string Owner;

    protected IShootable shooter;

    
    

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

    void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
    }

    public abstract void Move();

    public void Init(int _damage, IShootable _owner) 
    {
        Damage = _damage;
        shooter = _owner;
    }

    public int GetShootDirection() 
    {
        float shootDirec = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDirec > 0)
            return 1; //right
        else return -1; //left
    }


}
