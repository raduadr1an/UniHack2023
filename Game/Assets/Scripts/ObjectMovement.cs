using System.Collections;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float delay = 3f; // Delay in seconds

    void Start()
    {
        StartCoroutine(MoveAfterDelay());
    }

    IEnumerator MoveAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            //if (Vector2.Distance(transform.position, target.position) < 1f)
            //{
            //    target.position *= -1f;
            //}

            yield return null; // Wait for the next frame
        }
    }
}