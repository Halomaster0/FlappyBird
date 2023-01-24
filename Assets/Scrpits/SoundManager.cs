using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Function to play the jump sound
    public static void jump()
    {
        // Create a new game object with an AudioSource component
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        // Play the jump sound from the GameManager script
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().birdJump);
    }

    // Function to play the point sound
    public static void point()
    {
        // Create a new game object with an AudioSource component
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        // Play the point sound from the GameManager script
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().collect);

    }

    // Function to play the death sound
    public static void death()
    {
        // Create a new game object with an AudioSource component
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        // Play the death sound from the GameManager script
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().dead);

    }

    // Function to play the highscore sound
    public static void highScore()
    {
        // Create a new game object with an AudioSource component
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        // Play the highscore sound from the GameManager script
	    audiosource.PlayOneShot(FindObjectOfType<GameManager>().highscore);
}
}
