using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick Joystick;
    public float moveSpeed;
    public GameObject winText;
    public int winScore;

    private float hInput, vInput;
    private int score = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        hInput = Joystick.Horizontal * moveSpeed;
        vInput = Joystick.Vertical * moveSpeed;
        
        transform.Translate(hInput, vInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Carrot"))
            return;

        score++;
        Destroy(other.gameObject);

        if (score >= winScore)
        {
            winText.SetActive(true);
            Joystick.enabled = false;
            Destroy(Joystick.gameObject);
            vInput = 0;
            hInput = 0;
        }
    }
}
