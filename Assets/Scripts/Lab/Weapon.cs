using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected string Owner;

    //interface IShootable

    
    

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

    public abstract void OnHitWithCharacter();
    
    

    public abstract void Move();


    public int GetShootDirection() 
    {
        return 1;
    }


}
