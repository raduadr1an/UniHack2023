using UnityEngine;
using System.Collections;

public class slingshotShooting : MonoBehaviour
{
    public float bulletSpeed = 10;
    public Rigidbody bullet;

    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
    }
}