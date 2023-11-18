using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class optionsOnClick : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void TaskOnClick()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}