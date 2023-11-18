using UnityEngine;
using System.Collections;

public class slingshotShooting : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce = 20f;
    public GameObject bulletPrefab;

    public float timeBtwShots = 1.0f;  //Time between shots
    private float timeOfLastShot;

    private void Fire()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBody = bulletClone.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - timeOfLastShot >= timeBtwShots) //If the time elapsed is more than the fire rate, allow a shot
                {
                    Fire();
                    timeOfLastShot = Time.time;   //set new time of last shot
                }
            }
        }
    }
}