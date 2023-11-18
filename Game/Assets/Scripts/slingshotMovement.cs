using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshotMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject player;
    private Vector2 offset;

    public Camera cam;
    private Vector2 mousePos;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = getPlayer();
        offset = new Vector2(1f, 1f);
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            body.transform.position = new Vector2(player.transform.position.x + offset.x, player.transform.position.y + offset.y);
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            Vector2 lookDir = mousePos - body.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            body.rotation = angle;
        }
    }

    public GameObject getPlayer()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
}