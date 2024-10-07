using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    //damage 40
    private Rigidbody rb2d;
    private Vector2 force;

    public override void OnHitWithCharacter()
    {

    }

    public override void Move() 
    {
        Debug.Log("Rock move with Rigibody:force");
    }
    private void Start()
    {
        Move();
    }
}
