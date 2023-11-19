using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossAI : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Editor
    public Transform firePoint; // The point where the bullets will be spawned

    public float bulletSpeed = 10f; // Speed of the bullets
    public int bulletCount = 5; // Number of bullets to shoot
    public float spreadAngle = 30f; // Spread angle in degrees
    private float shootTimer = 0f;
    public float shootInterval = 2.0f;

    private void Update()
    {
        if (Time.time - shootTimer >= shootInterval) //If the time elapsed is more than the fire rate, allow a shot
        {
            ShootProjectile();
            shootTimer = Time.time;   //set new time of last shot
        }
    }

    public void ShootProjectile()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = (i - (bulletCount - 1) / 2f) * spreadAngle / (bulletCount - 1);

            // Calculate direction based on the angle
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.right;

            // Instantiate the bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Shoot the bullet in the calculated direction
            bulletRb.velocity = direction.normalized * bulletSpeed;
        }
    }
}