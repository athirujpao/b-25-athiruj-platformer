using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    
    private Rigidbody2D rb2d;
    private Vector2 force;

    public override void OnHitWith(Character character)
    {
        if (character is Player) { character.TakeDamage(Damage);  }
        //character.TakeDamage(Damage);
    }

    public override void Move() 
    {
        
        rb2d.velocity = new Vector2(GetShootDirection() * 5, rb2d.velocity.y);
        
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Damage = 20;
        force = new Vector2 (GetShootDirection() * 1, 1);
        Move();
    }
}
