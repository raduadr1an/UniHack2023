using System.Collections;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public float delay = 3f; // Delay in seconds

    private Vector2 targetPosition;

    void Start()
    {
        StartCoroutine(MoveAfterDelay());
    }

    IEnumerator MoveAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // Store the player's position at the end of the delay
        targetPosition = player.position;

        while (true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

            if (Vector2.Distance(transform.position, targetPosition) < 1f)
            {
                // If the GameObject reaches the target position, stop moving
                break;
            }

            yield return null; // Wait for the next frame
        }
    }
}