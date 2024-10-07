using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private Player player;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnsPoint;

    [SerializeField] private float bulletSpawnTime;
    [SerializeField] private float bulletTimer;

    private void Update()
    {
        bulletTimer -= Time.deltaTime;

        Behavior();

        if (bulletTimer <= 0)
        {
            bulletTimer = bulletSpawnTime;
        }
    }
    
    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance < attackRange) 
        {
            Shoot();
        }

        

        


    }

    private void Shoot()
    {
        if (bulletTimer <= 0)
        {
            Instantiate(bullet, bulletSpawnsPoint.position, Quaternion.identity);
        }
        
        
    }
}
