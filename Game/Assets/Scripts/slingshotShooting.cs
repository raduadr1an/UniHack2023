using UnityEngine;
using System.Collections;

public class slingshotShooting : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce = 20f;
    public GameObject bulletPrefab;

    private void Fire()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBody = bulletClone.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
    }
}