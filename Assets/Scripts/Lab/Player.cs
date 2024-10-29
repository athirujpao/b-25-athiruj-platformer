using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }

    public float BulletSpawnTime { get; set; }
    public float BulletTimer { get; set; }

    public void Shoot() 
    {
        // click mouse to shoot 
        if (Input.GetButtonDown("Fire1") && (BulletTimer >= BulletSpawnTime)) 
        {
            Instantiate(Bullet, BulletSpawnPoint.position,Quaternion.identity );
            
            BulletTimer = 0;
        }
    }
    public void OnHitWithEnemy() { }

    private void Update()
    {
        Shoot();
    }
}
