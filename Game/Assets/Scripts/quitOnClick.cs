using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitOnClick : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }
}