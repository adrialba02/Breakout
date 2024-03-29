﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    public int level = 1;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        Win();
    }
  
    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level1");
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
    }


    public void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
        /*
        for(int i = 0; i < this.bricks.Length; i++)
        {
            this.bricks[i].ResetBrick();
        }
        */
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");

        Debug.Log(" Game Over! I'll give you another chance ");
        //NewGame();
    }

    public void Restart()
    {
        this.lives--;
        Debug.Log("Lives: " + this.lives);

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    public void Hit(Brick brick)
    {
        this.score += brick.points;

        Debug.Log("Score: " + this.score);
        
    }

    public bool Win()
    {
        if (score == 210)
        {
            SceneManager.LoadScene("Winner");
            return true;
        }
        else
        {
            return false;
        }
    }
}
