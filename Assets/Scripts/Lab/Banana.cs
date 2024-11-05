using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    //set it on Inspector to 4 and Damage 30
    [SerializeField] private float speed;

    
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.deltaTime;
        float newY = transform.position.x;
        Vector2 newPosi = new Vector2(newX, newY);
        transform.position = newPosi;
        Debug.Log("Banana move with constants speed using Tranfrom");
    }

    //I don't know we can use this too override(mean the OnHit one). Please let me know if you see this because in the OOP, they said they can only override Move(). TY TA
    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(Damage);
        }
       Console.WriteLine($"{this.name}: ");
    }

    private void Start()
    {
        Damage = 30;
        speed = 4;
        
        Move();
    }




}
