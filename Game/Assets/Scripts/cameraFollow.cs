using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform followTransform;

    public float maxScreenPoint = 0.8f;
    public float speed = 1f;

    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);
        Vector3 position = (followTransform.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;
        Vector3 destination = new Vector3(position.x, position.y, -10);

        transform.position = Vector2.Lerp(transform.position, destination, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}