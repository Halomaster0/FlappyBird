using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Variable for controlling the speed of the pipes
    public float speed = 5f;
    // Variable to store the left edge of the screen
    private float leftEdge;

    // Function that runs on the first frame
    private void Start()
    {
        // Get the left edge of the screen in world coordinates and subtract 1 to account for offscreen space
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Function that runs every frame
    private void Update()
    {
        // Move the pipes to the left based on the speed and time since the last frame
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the pipes have moved past the left edge of the screen
        if(transform.position.x < leftEdge)
        {
            // If so, destroy the pipes game object
            Destroy(gameObject);
        }
    }
}
