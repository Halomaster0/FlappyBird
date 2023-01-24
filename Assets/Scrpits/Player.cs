using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference to the Sprite renderer component
    private spriteRenderer spriteRenderer;
    // Array of sprites for animation
    public sprite[] sprites;
    // Sound array for events
    // public Sound[] sounds; 
    // Index for the current sprite in the animation
    private int spriteIndex;
    // Vector for storing the direction of movement
    private Vector3 direction;
    // Variable for gravity force
    public float gravity = -9.8f;
    // Variable for jump strength
    public float strength = 5.0f;
    // Reference to the GameManager script
    public GameManager script;

    // Function that runs when the script is first enabled
    private void Awake()
    {
        // Get the sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Function that runs when the object is enabled
    private void OnEnable()
    {
        // Set the player's position to the starting point
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        // Reset the direction
        direction = Vector3.zero;
    }

    // Function that runs on the first frame
    private void Start()
    {
        // Invoke the AnimateSprite function repeatedly with a delay of 0.15 seconds
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Function that runs every frame
    private void Update()
    {
        // Check for spacebar or left mouse button input
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Set the upward direction and apply jump sound
            direction = Vector3.up * strength;
            SoundManager.jump();
        }

        // Apply gravity to the direction vector
        direction.y += gravity * Time.deltaTime;
        // Move the player based on the direction vector
        transform.position += direction * Time.deltaTime;
    }

    // Function to animate the sprite
    private void AnimateSprite()
    {
        // Increment the sprite index
        spriteIndex++;

        // If the sprite index is greater than or equal to the number of sprites in the array
        if(spriteIndex >= sprites.Length)
        {
            // Set the sprite index back to 0
            spriteIndex = 0;
        }

        // Set the sprite renderer's sprite to the current sprite in the animation
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Function that runs when the player collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the "Obstacle" tag
        if(other.gameObject.tag == "Obstacle")
        {
            // Call the GameOver function in the GameManager script and play death sound
            FindObjectOfType<GameManager>().GameOver();
            SoundManager.death();
        } 
        // Check if the object has the "Scoring" tag
        else if (other.gameObject.tag == "Scoring")
        {
            // Call the IncreaseScore function in the GameManager script and play point sound
            FindObjectOfType<GameManager>().IncreaseScore();
            SoundManager.point();
        }
    }
}

