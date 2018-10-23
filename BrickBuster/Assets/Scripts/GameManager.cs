using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int lives = 3;
    public int bricks = 0;
    public int score = 0;
    public float resetDelay = 1f;
    public GameObject paddle;
    public GameObject deathParticles;

    public Text livesText;
    public Text scoreText;
    public Text gameOverText;

    public LevelManager lm;

    private GameObject clonePaddle;

    //We’re using Awake to call setup so we will run this before any other code. This allows us to make sure our game is ready for play prior to the player being able to modify any of the variables or trigger any functions.
    private void Awake()
    {

        SetUp();

    }

    private void SetUp() {

        SetUpPaddle();
        livesText.text = "Balls Remaining: " + lives;
        scoreText.text = "Score: " + score;
        lm.LoadNextLevel();
        bricks = 0;
        bricks = GameObject.FindGameObjectsWithTag("Brick").Length;

    }

    private void SetUpPaddle() {

        Destroy(clonePaddle);
        clonePaddle = Instantiate(paddle, paddle.transform.position, paddle.transform.rotation) as GameObject;

    }

    public void LoseLife() {

        lives--;
        livesText.text = "Balls remaining: " + lives;
        Destroy(clonePaddle);

        //The rotation we are simply setting to “nothing” with Quaternion.identity. 
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);

        if (lives > -1) {

            Invoke("SetUpPaddle", resetDelay);

        }

        CheckGameOver();

    }

    public void IncreaseScore() {

        bricks--;
        score++;
        scoreText.text = "Score: " + score;
        CheckGameOver();

    }

    private void CheckGameOver() {

        if (bricks < 1) {

            //Debug.Log("Player Wins!");
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Great Job!";
            Time.timeScale = .25f;
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            Invoke("LevelComplete", resetDelay);

        }

        if (lives < 0) {

            //Debug.Log("Player lost");
            gameOverText.gameObject.SetActive(true);
            livesText.text = "GAME OVER";
            gameOverText.text = "Try Again";
            Time.timeScale = .25f; //slows the speed at which time passes in-game, return this to normal speed on the invoked fxns
            Invoke("Reset", resetDelay); //calls a function after a delay

        }



    }


    //Activate the Multiplier and set the duration before it expires.
    public void MultiplierActivate(float multiplierDuration) {

        score++;
        scoreText.fontStyle = FontStyle.Bold;
        scoreText.fontSize = 26;
        scoreText.color = Color.green;
        Invoke("MultiplierDeactivate", multiplierDuration);

    }

    //We will use this to reset all the changes to the GameObjects and their components.
    private void MultiplierDeactivate() {

        scoreText.fontStyle = FontStyle.Normal;
        scoreText.fontSize = 20;
        scoreText.color = Color.black;

    }

    private void LevelComplete() {

        gameOverText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Destroy(clonePaddle);
        SetUp();

    }

    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BrickBusterScene");
    }

}
