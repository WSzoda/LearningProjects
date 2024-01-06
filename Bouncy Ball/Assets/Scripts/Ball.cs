using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Ball : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;

    private Rigidbody2D _rb;

    // private void FixedUpdate()
    // {
    //     transform.Translate(new Vector2(xSpeed, ySpeed));
    // }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.AddForce(new Vector2(xSpeed, ySpeed), ForceMode2D.Impulse);
    }


    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.CompareTag("Wall"))
        // {
        //     xSpeed = -xSpeed;
        // }
        // if (other.gameObject.CompareTag("Ceiling"))
        // {
        //     ySpeed = -ySpeed;
        // }
        // if (other.gameObject.CompareTag("Ceiling"))
        // {
        //     ySpeed = -ySpeed;
        // }
    }
}
