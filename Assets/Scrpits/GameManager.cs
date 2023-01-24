using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // AudioClips for different sound effects
    public AudioClip birdJump;
    public AudioClip collect;
    public AudioClip dead;
    public AudioClip highscore;

    // Variable to check if high score has been set
    private bool hs;

    // Reference to the player object
    public Player player;

    // Variable to track the current score
    private int score;

    // Text UI element to display the current score
    public Text scoreText;

    // Play button UI element
    public GameObject playButton;

    // Game over UI element
    public GameObject gameOver;

    // Variable to track the high score
    private int highScore;

    // Number of times the game has been played
    private int nop = 0;

    // Variable to track the top score
    private int top;

    // Text UI element to display the high score
    public Text highscoreText;

    // Function that runs when the script is first enabled
    private void Awake()
    {
        // Set the target frame rate to 60
        Application.targetFrameRate = 60;
        // Call the Pause function to set the game to a paused state
        Pause();
    }

    // Function that runs when the script is first enabled
    private void Start()
    {   
        // Check if the game has been played before
        if(nop == 0)
        {
            // Get the high score from player preferences and set it to the highscoreText UI element
            highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        } 
    }

    // Function to start the game
    public void Play()
    {
        // Increment the number of plays
        nop++;
        // Reset the score
        score = 0;
        // Set the scoreText UI element to the current score
        scoreText.text = score.ToString();

        // Deactivate the play button
        playButton.SetActive(false);
        // Deactivate the game over UI element
        gameOver.SetActive(false);

        // Set the time scale to 1 (unpaused)
        Time.timeScale = 1f;
        // Enable the player script
        player.enabled = true;

        // Get all the pipes in the scene
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        // Loop through all the pipes and destroy them
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    // Function to pause the game
    public void Pause()
    {
        // Set the time scale to 0 (paused)
        Time.timeScale = 0f;
        // Disable the player script
        player.enabled = false;
    }

    // Function to end the game
    public void GameOver()
    {
        // Check if the current score is a new high score
        HighScore();
        // Activate the game over UI element
        gameOver.SetActive(true);
        // Activate the play button
        playButton.SetActive(true);
        // Call the Pause function
        Pause();
    }

    // Function to increase the score
    public void IncreaseScore()
    {
        // Increment the score
        score++;
        // Set the scoreText UI element to the current score
        scoreText.text = score.ToString();
    }

    // Function to check and set a new high score
    void HighScore()
    {
        // Check if the current score is greater than the current high score
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            // Set the new high score in player preferences
            PlayerPrefs.SetInt("HighScore", score);
            // Set the highscoreText UI element to the new high score
            highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            //Call the HighScore function of SoundManager
            SoundManager.highScore();
        }
    }
}

   
