using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy, IShootable
{

    public float attackRange;
    public  Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }

    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }


    
    private void Update()
    {
        BulletTimer -= Time.deltaTime;

        Behavior();

        UpdateHealthSlider();


    }

    void Start()
    {
        base.HealthStart();
        Init(100);
        BulletTimer = 0.0f;
        BulletSpawnTime = 5.0f;
        DamageHit = 30;
        attackRange = 6;
        player = GameObject.FindAnyObjectByType<Player>();
    }
    

    public override void Behavior()
    {
        if (player == null)
        {
            Debug.LogWarning("Player has been destroyed, skipping behavior.");
            return; // Prevent further execution if the player is destroyed
        }

        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= attackRange && BulletTimer <= 0) 
        {
            Shoot();
            BulletTimer = BulletSpawnTime; // reset the time after shooting
        }

    }

    public void Shoot()
    {
        if (BulletTimer <= 0)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Rock rock = obj.GetComponent<Rock>();
            rock.Init(30, this);


            
        }
        
        
    }
    
}
