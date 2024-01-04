using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BalloonController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public TextMeshProUGUI text;
    private int _score = 0;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.y > 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private void FixedUpdate()
    {
        transform.Translate(0, speed, 0);
    }

    private void OnMouseDown()
    {
        _score++;
        text.text = _score.ToString();
        _audioSource.Play();

        speed += 0.01f;
        ResetPosition();
    }

    private void ResetPosition()
    {
        var xPosition = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector2(xPosition, -6);
    }
}
