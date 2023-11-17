using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    private GameObject player;

    public static object Instance { get; internal set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == getPlayer())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public GameObject getPlayer()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
}