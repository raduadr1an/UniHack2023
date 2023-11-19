using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject player;
    public GameObject boss;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = getPlayer();
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            Vector2 lookDir = (Vector2)player.transform.position - body.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            body.rotation = angle;
        }
    }

    public GameObject getPlayer()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
}