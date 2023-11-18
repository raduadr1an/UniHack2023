using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class backOnClick : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void TaskOnClick()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}