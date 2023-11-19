using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossAI : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 5.0f; 
    public int hitCount = 10;
    public float speed = 5.0f;
    private Transform player;
    public Transform Target;
    public float shootInterval = 1.0f;
    private float shootTimer = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Vector2 direction = player.position - transform.position;
        //transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;

        if (hitCount <= 0)
        {
            Destroy(gameObject);
        }

        if (Time.time - shootTimer >= shootInterval) //If the time elapsed is more than the fire rate, allow a shot
        {
            ShootProjectile();
            shootTimer = Time.time;   //set new time of last shot
        }
    }

    public void TakeDamage(int damage)
    {
        hitCount -= 1; 
    }

    public void ShootProjectile()
    {
        int numberOfProjectiles = 5;
        float spreadAngle = 45f;
        float startAngle = -spreadAngle / 2;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angle = startAngle + spreadAngle * i / (numberOfProjectiles - 1);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * directionToPlayer;
            projectile.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
        }
        // Calculate the direction to the target
        Vector2 direction1 = Target.position - transform.position;
        // Calculate the angle to the target
        float angle1 = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
        // Rotate the watchtower to face the target
        transform.rotation = Quaternion.Euler(0, 0, angle1);
    }
}