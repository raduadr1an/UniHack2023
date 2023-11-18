using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrderInLayer : MonoBehaviour
{
    public float thresholdX = 5f; // Set the X value where you want to change the sorting order
    public int newSortingOrder = 2; // Set the new sorting order value

    private bool hasPassedThreshold = false;

    // Update is called once per frame
    private void Update()
    {
        if (!hasPassedThreshold && transform.position.x > thresholdX)
        {
            // If the GameObject passes the thresholdX for the first time, change sorting order
            hasPassedThreshold = true;
            changeOrderInLayer();
        }
    }

    private void changeOrderInLayer()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            renderer.sortingOrder = newSortingOrder;
        }
        else
        {
            Debug.LogWarning("Renderer component not found on the GameObject.");
        }
    }
}