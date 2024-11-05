using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    //set it on Inspector to 4 and Damage 30
    [SerializeField] private float speed;

    public override void Move()
    {
        Debug.Log("Banana move with constants speed using Tranfrom");
    }

    //I don't know we can use this too override(mean the OnHit one). Please let me know if you see this because in the OOP, they said they can only override Move(). TY TA
    public override void OnHitWith(Character character)
    {
       
    }

    private void Start()
    {
        Move();
    }




}
