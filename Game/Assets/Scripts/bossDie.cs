using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDie : MonoBehaviour
{
    public Transform transformPos;
    private int collisionCount = 0;

    private void Start()
    {
        transformPos = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isOver())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collisionCount++;
        }
    }

    private bool isOver()
    {
        if (collisionCount >= 15)
        {
            collisionCount = 0;
            return true;
        }
        return false;
    }
}