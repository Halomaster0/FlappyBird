
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public AudioClip birdJump;
    public AudioClip collect;
    public AudioClip dead;
    public AudioClip highscore;

    private bool hs;

    public Player player;

    private int score;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    private int highScore;
    //number of plays
    private int nop = 0;

    private int top;

    public Text highscoreText;
    private void Awake()
    {

        Application.targetFrameRate = 60;
        Pause();
 
    }

    private void Start()
    {   
        if(nop == 0)
        {
           highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        } 

    }
    public void Play()
    {
        nop++;
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

    }
    public void GameOver()
    {
        HighScore();
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
   
   
   void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            SoundManager.highScore();
        }


    }

}
