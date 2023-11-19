using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnDeath : MonoBehaviour
{
    public string playerTag = "Player";
    public string bulletTag = "Bullet";

    public int hitCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && collision.gameObject.CompareTag(bulletTag))
        {
            hitCount++;
            if (hitCount >= 5) ResetScene();
        }
    }

    private void ResetScene()
    {
        // Reset the hit count
        hitCount = 0;

        // Reset the scene by reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}