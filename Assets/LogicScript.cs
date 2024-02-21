using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text highScoreText;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource point;
    public AudioSource start;
    public AudioSource endGame;

    private void Start()
    {
        if (!start.isPlaying)
        {
            start.Play();
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0).ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if(!point.isPlaying)
        {
            point.Play();
        }
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if(!endGame.isPlaying)
        {
            endGame.Play();
        }

        if (playerScore > PlayerPrefs.GetInt("High Score",0))
        {
            PlayerPrefs.SetInt("High Score", playerScore);
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0).ToString();
        gameOverScreen.SetActive(true);
    }

    public void goHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
