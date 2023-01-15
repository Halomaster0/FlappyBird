using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static void jump()
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().birdJump);
    }

    public static void point()
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().collect);

    }

    public static void death()
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().dead);

    }

    public static void highScore()
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(FindObjectOfType<GameManager>().highscore);
        
    }


}
