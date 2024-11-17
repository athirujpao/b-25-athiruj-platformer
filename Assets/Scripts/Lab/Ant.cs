using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    private void Start() 
    {
        base.HealthStart();
        
        
        
    }
    private void FixedUpdate()
    {
        UpdateHealthSlider();
        Behavior();
    }
    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FilpCharecter();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0) 
        {
            FilpCharecter();
        }
    }

    private void FilpCharecter()
    {
        velocity *= -1;

        
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ant doesn't have weapon to shoot then make check if player hit the ant with collison
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null) 
        {
            int damage = 10;  // Amount of damage dealt by the Ant
            player.TakeDamage(damage);

            
        }
    }
}
