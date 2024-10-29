using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    // needed to make to property
    GameObject Bullet { get; set; } 

    Transform BulletSpawnPoint { get; set; }

    public float BulletSpawnTime { get; set; }
    public float BulletTimer { get; set; }



    public void Shoot();
    

    
}
