using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BulletHits : MonoBehaviour
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
            transformPos.position = new Vector3(-5.8f, 2.2f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collisionCount++;
            Debug.Log("Collision Count: " + collisionCount);
        }
    }

    private bool isOver()
    {
        if (collisionCount == 5)
        {
            collisionCount = 0;
            return true;
        }
        return false;
    }
}