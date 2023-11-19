using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        LoadScene.Instance.LoadScenes("mainHub");
    }
}