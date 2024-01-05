using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    private bool _gameStarted = false;
    
    public GameObject tapImage;
    
    public TextMeshProUGUI scoreText;
    private int _score = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_gameStarted)
        {
            _gameStarted = true;
            Destroy(tapImage.gameObject);
            StartSpawning();
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f ,spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPosition = spawnPoint.position;
        float xOffset = Random.Range(-maxX, maxX);

        spawnPosition.x += xOffset;

        Instantiate(block, spawnPosition, Quaternion.identity);

        _score++;

        scoreText.text = _score.ToString();
    }
}
