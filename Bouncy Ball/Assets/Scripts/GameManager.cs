using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameNameText;
    public TextMeshProUGUI ctaText;

    public Ball ball;

    private bool _gameStarted;
    private int _score = 0;
    
    private void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        if (!_gameStarted)
        {
            StartGame();
            _gameStarted = true;
            ball.LaunchBall();
        }
    }

    private void StartGame()
    {
        gameNameText.enabled = false;
        ctaText.enabled = false;
        scoreText.enabled = true;
    }

    public void IncrementScore()
    {
        _score += 100;
        scoreText.text = _score.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    
    
}
