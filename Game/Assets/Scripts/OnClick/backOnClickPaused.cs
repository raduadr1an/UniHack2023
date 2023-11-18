using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backOnClickPaused : MonoBehaviour
{
    public GameObject pauseMenu;

    public void backClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}