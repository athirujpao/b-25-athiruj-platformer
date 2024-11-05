using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [SerializeField] private float attackRange;
    public Player player;

    GameObject Bullet { get; set; }
    Transform BulletSpawnsPoint { get; set; }

    float BulletSpawnTime { get; set; }
    float BulletTimer { get; set; }

    private void Update()
    {
        BulletTimer -= Time.deltaTime;

        Behavior();

        if (BulletTimer <= 0)
        {
            BulletTimer = BulletSpawnTime;
        }
    }

    void Start()
    {
        Init(30);
        BulletTimer = 0.0f;
        BulletSpawnTime = 5.0f;
        DamageHit = 30;
        attackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
    }
    void FixedUpdate()
    {
        BulletTimer += Time.fixedDeltaTime;
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= attackRange) 
        {
            Shoot();
        }

        

        


    }

    public void Shoot()
    {
        if (BulletTimer <= 0)
        {
            
            Instantiate(Bullet, BulletSpawnsPoint.position, Quaternion.identity);
        }
        
        
    }
}
