using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Ball : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public GameManager gameManager;

    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void LaunchBall()
    {
        _rb.AddForce(new Vector2(xSpeed, ySpeed), ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.IncrementScore();
            var vel = _rb.velocity;
            vel *= 1.1f;
            _rb.velocity = vel;
        }

        if (other.gameObject.CompareTag("ResetZone"))
        {
            gameManager.ResetGame();
        }
        
    }
}
