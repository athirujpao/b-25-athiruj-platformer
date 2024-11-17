using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }

    public float BulletSpawnTime { get; set; }
    public float BulletTimer { get; set; }
    private void Start()
    {
        base.HealthStart();
        Init(100);
        
        
    }

    public void Shoot() 
    {
        // click mouse to shoot 
        if (Input.GetButtonDown("Fire1") && (BulletTimer >= BulletSpawnTime)) 
        {
            
            
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity );
            

            Banana banana = obj.GetComponent<Banana>();
            banana.Init(20, this); // Set ownership to this Player instance
            BulletTimer = 2;
            
        }
    }
    

    private void Update()
    {
        UpdateHealthSlider();
        Shoot();
    }

}
